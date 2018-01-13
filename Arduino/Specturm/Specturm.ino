#include <EEPROM.h>


long previousMillis = 0;

#include <Adafruit_NeoPixel.h>
#ifdef __AVR__
  #include <avr/power.h>
#endif

#define PIN 6

// Parameter 1 = number of pixels in strip
// Parameter 2 = Arduino pin number (most are valid)
// Parameter 3 = pixel type flags, add together as needed:
//   NEO_KHZ800  800 KHz bitstream (most NeoPixel products w/WS2812 LEDs)
//   NEO_KHZ400  400 KHz (classic 'v1' (not v2) FLORA pixels, WS2811 drivers)
//   NEO_GRB     Pixels are wired for GRB bitstream (most NeoPixel products)
//   NEO_RGB     Pixels are wired for RGB bitstream (v1 FLORA pixels, not v2)
//   NEO_RGBW    Pixels are wired for RGBW bitstream (NeoPixel RGBW products)
Adafruit_NeoPixel strip = Adafruit_NeoPixel(100, PIN, NEO_GRB + NEO_KHZ800);

// IMPORTANT: To reduce NeoPixel burnout risk, add 1000 uF capacitor across
// pixel power leads, add 300 - 500 Ohm resistor on first pixel's data input
// and minimize distance between Arduino and first pixel.  Avoid connecting
// on a live circuit...if you must, connect GND first.

// VARIABLES

// INT
int stripLength = strip.numPixels();
int currentPixel = 0;
int state;
int blue = 0;
int green = 0;
int red = 255;

int startPixel = 0;
int endPixel = 0;

int i = 0, j = 0;
int wait = 100;


bool rainbowCycleBool = false;
bool rainbowFullBool = false;
bool sentCommand = false;
bool boardReady = true;

int EEPROMlength = 130;

void setup() {
  Serial.begin(9600);
  strip.begin();
  strip.show(); // Initialize all pixels to 'off'
}

void loop() {
  String data = Serial.readString();

    if(EEPROM.read(EEPROMlength) != stripLength){
      stripLength = EEPROM.read(EEPROMlength);
    }
    
    // Changes the Length Of The Strip
    if(data.substring(0,17) == "ChangeStripLength"){
       stripLength = data.substring(17).toInt();
       EEPROM.write(EEPROMlength, stripLength);
    }
    
    // RainbowCycle Animation
    if(data.substring(0,12) == "RainbowCycle" || rainbowCycleBool){

      if(rainbowFullBool) rainbowFullBool = false;
      
      // Reset Color
      if(data.substring(0,7) == "Rainbow"){
        i = 0, j = 0;
        wait = data.substring(12).toInt();
        sentCommand = true;
      }
      
      //Serial.println(wait);
      
      rainbowCycleBool = true;
      
      rainbowCycle(wait);
    }

    // RainbowFull Animation
    if(data.substring(0,11) == "RainbowFull" || rainbowFullBool){

      if(rainbowCycleBool) rainbowCycleBool = false;
      
      // Reset Color
      if(data.substring(0,7) == "Rainbow"){
        i = 0, j = 0;
        wait = data.substring(11).toInt();
        sentCommand = true;
      }
      
      //Serial.println(wait);
      
      rainbowFullBool = true;
      
      rainbowFull(wait);
    }

    // Solid Color
    if(data.substring(0,10) == "SolidColor"){
      String between = "";
      
      if(rainbowCycleBool) rainbowCycleBool = false;
      if(rainbowFullBool) rainbowFullBool = false;

      
      String redString = data.substring(10,13);
      String greenString = data.substring(13,16);
      String blueString = data.substring(16,19);

      // Allows User to 
      if(data.substring(19,20) == "-"){
        data = data.substring(20);
        int i = data.lastIndexOf("-");
        startPixel = data.substring(0, i).toInt();
        endPixel = data.substring(i+1).toInt();

        // Corrects for First Pixel being 0
        startPixel --;
        endPixel --;
        
        /*
         * Serial.println(data);
         * Serial.println(startPixel);
         * Serial.println(endPixel);
         * Serial.println(i);
         */
      }
      
      else{
        startPixel = 0;
        endPixel = stripLength;
      }
      
      solidColor(strip.Color(redString.toInt(),greenString.toInt(),blueString.toInt()), startPixel, endPixel);
    }

    // Turns Lights Off
    if(data.substring(0,7) == "turnOff"){
      if(rainbowCycleBool) rainbowCycleBool = false;
      if(rainbowFullBool) rainbowFullBool = false;

      
      strip.clear();
      strip.show();
    }
   
    
}



// Fill the dots one after the other with a color
void colorWipe(int wait, float color) {

  if(currentPixel <= stripLength){
      strip.setPixelColor(currentPixel, color);
      strip.show();
      currentPixel ++;
      
      if (blue < 255 && green == 0) {
        blue += 5;
        red -= 5;
        
        Serial.print("Red : ");
        Serial.println(red, DEC);
        Serial.print("Blue : ");
        Serial.println(blue, DEC);
        
        if(blue >= 225){
          blue = 255;
          red = 0;
        }
    }
    else if(red == 0 && blue > 0){
      blue -= 5;
      green += 5;
      
      Serial.print("Green : ");
      Serial.println(green, DEC);
      Serial.print("Blue : ");
      Serial.println(blue, DEC);
    }
    
      else {
          blue = 0;
          green = 0;
          red = 255;
          Serial.println("restarted");
      }
      delay(wait);
  }
  
  else { 
      currentPixel = 0;
      strip.clear();
    }
}

// SOLID COLOR
void solidColor(float color, int firstPixel, int lastPixel){

  currentPixel = firstPixel;
  while(currentPixel <= lastPixel){
      strip.setPixelColor(currentPixel, color);
      strip.show();
      currentPixel ++;
    }
}


void rainbowCycle(long wait){

  // Delay
  unsigned long currentMillis = millis();
  if(currentMillis - previousMillis > wait || sentCommand) {
    previousMillis = currentMillis;
    
    if(j < 256){

      for(i=0; i<stripLength; i++) {
        strip.setPixelColor(i, Wheel((i+j) & 255));
      }

      strip.show();
      j++;
    } else j = 0;
  }
  if(sentCommand) sentCommand = false;
}


void rainbowFull(long wait) {
// Delay
  unsigned long currentMillis = millis();
  if(currentMillis - previousMillis > wait || sentCommand) {
    previousMillis = currentMillis;
    
    if(j < 256*5){

      for(i=0; i<stripLength; i++) {
        strip.setPixelColor(i, Wheel(((i * 256 / stripLength) + j) & 255));
      }

      strip.show();
      j++;
    } else j = 0;
  }
  if(sentCommand) sentCommand = false;
}

// Input a value 0 to 255 to get a color value.
// The colours are a transition r - g - b - back to r.
long Wheel(byte WheelPos) {
  WheelPos = 255 - WheelPos;
  if(WheelPos < 85) {
    return strip.Color(255 - WheelPos * 3, 0, WheelPos * 3);
  }
  if(WheelPos < 170) {
    WheelPos -= 85;
    return strip.Color(0, WheelPos * 3, 255 - WheelPos * 3);
  }
  WheelPos -= 170;
  return strip.Color(WheelPos * 3, 255 - WheelPos * 3, 0);
}

