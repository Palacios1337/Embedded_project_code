#include <msp430.h> 
#include <time.h>

volatile float lightvalue = 0;
volatile float tempvalue = 0;
volatile float motionvalue =0;

int lighton = 0;


#define CALADC_15V_30C  *((unsigned int *)0x1A1A)                 // Temperature Sensor Calibration-30 C
                                                                  // See device datasheet for TLV table memory mapping
#define CALADC_15V_85C  *((unsigned int *)0x1A1C)                 // Temperature Sensor Calibration-High Temperature (85 for Industrial, 105 for Extended)

volatile float IntDegF;
volatile float IntDegC;

int Number = 1;

void initialize_Adc(){
     ADCCTL0 &= ~ADCIFG;
     ADCMCTL0 &= ADCINCH_0;
     ADCMEM0=0x00000000;
     ADCCTL0=0x0000;
     ADCCTL1=0x0000;
}

void ConfigureAdc_temp(){
    ADCCTL0 &= ~ADCSHT;
    ADCCTL0 |= ADCSHT_8 | ADCON;                                  // ADC ON,temperature sample
    ADCCTL1 |= ADCSHP;                                            // s/w trig, single ch/conv, MODOSC
    ADCCTL1 |=ADCSSEL_2;
    ADCCTL2 &= ~ADCRES;                                           // clear ADCRES in ADCCTL
    ADCCTL2 |= ADCRES_2;                                          // 12-bit conversion results
    ADCMCTL0 |= ADCINCH_12 | ADCSREF_1;                           // ADC input ch A12 => temp sense
    ADCIE |=ADCIE0;
}

void ConfigureAdc_photosensor(){
    ADCCTL0 &= ~ADCSHT;
    ADCCTL0 |=ADCSHT_8;
    ADCCTL0 |= ADCON;

    ADCCTL1 |=ADCSSEL_2;
    ADCCTL1 |= ADCSHP;

    ADCCTL2 &= ~ADCRES;
    ADCCTL2 |= ADCRES_2;
    ADCMCTL0 |=  ADCINCH_9 | ADCSREF_1 ;
    ADCIE |= ADCIE0;
}

void ConfigureAdc_motionsensor(){
    ADCCTL0 &= ~ADCSHT;
    ADCCTL0 |=ADCSHT_8;
    ADCCTL0 |= ADCON;

    ADCCTL1 |=ADCSSEL_2;
    ADCCTL1 |= ADCSHP;

    ADCCTL2 &= ~ADCRES;
    ADCCTL2 |= ADCRES_2;
    ADCMCTL0 |=  ADCINCH_2 | ADCSREF_1 ;
    ADCIE |= ADCIE0;
}


int main(void)
{

    P1SEL0 |= BIT2;
    P1SEL1 |= BIT2;

    P5SEL0 |= BIT0 | BIT1;
    P5SEL1 |= BIT0 | BIT1;

    WDTCTL = WDTPW | WDTHOLD;
    PM5CTL0 &= ~LOCKLPM5;

    while(1){

        if (Number == 1 )
              {
                  initialize_Adc();
                  ConfigureAdc_photosensor(); // value 3800 is off or less
                  ADCCTL0 |= ADCENC | ADCSC;

                  while((ADCCTL0 & ADCIFG) == 0);
                  _delay_cycles(200000);

                  lightvalue = ADCMEM0;


                  if (lightvalue > 3000){

                      lighton = 1;


                  }
                  else{

                      lighton = 0;

                  }

                  Number = 2;
              }
         else if (Number == 2)
              {
                  initialize_Adc();
                  PMMCTL0_H = PMMPW_H;
                  PMMCTL2 |= INTREFEN | TSENSOREN | REFVSEL_0;
                  ConfigureAdc_temp();
                  ADCCTL0 |= ADCENC | ADCSC;

                  while((ADCCTL0 & ADCIFG) == 0);
                  _delay_cycles(200000);

                  tempvalue = ADCMEM0;
                  IntDegC = (tempvalue-CALADC_15V_30C)*(85-30)/(CALADC_15V_85C-CALADC_15V_30C)+30;
                  IntDegF = 9*IntDegC/5+32;
                  Number = 3;
              }
         else if (Number == 3)
              {
                  initialize_Adc();
                  ConfigureAdc_motionsensor();
                  ADCCTL0 |= ADCENC | ADCSC;
                  while((ADCCTL0 & ADCIFG) == 0);
                  _delay_cycles(200000);

                  motionvalue = ADCMEM0;
                  Number = 1;
              }


    }
}
