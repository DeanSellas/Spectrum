long previousMillis = 0;
bool rainbowAnimation = false;
bool sentCommand = false;
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
Adafruit_NeoPixel strip = Adafruit_NeoPixel(10, PIN, NEO_GRB + NEO_KHZ800);

// IMPORTANT: To reduce NeoPixel burnout risk, add 1000 uF capacitor across
// pixel power leads, add 300 - 500 Ohm resistor on first pixel's data input
// and minimize distance between Arduino and first pixel.  Avoid connecting
// on a live circuit...if you must, connect GND first.

// VARIABLES

// INT
int stripLength = strip.numPixels();
int currentPixel = 0;
int state;
bool test = true;
int blue = 0;
int green = 0;
int red = 255;

int i = 0, j = 0;

void setup() {
  Serial.begin(9600);
  strip.begin();
  strip.show(); // Initialize all pixels to 'off'
  Serial.print("Ready");
  
}

void loop() {

    //colorWipe(100, strip.Color(red, green, blue));
    //solidColor(strip.Color(0,255,0));
    String data = Serial.readString();
    
    if(data.substring(0,7) == "Rainbow" || rainbowAnimation){
      // Reset Color
      if(data.substring(0,7) == "Rainbow") i = 0, j = 0;
      
      int wait = data.substring(7).toInt();
      
      rainbowAnimation = true;
      sentCommand = true;
      rainbow(wait);
    }
    if(data.substring(0,10) == "SolidColor"){
      rainbowAnimation = false;

      
      String redString = data.substring(10,13);
      String greenString = data.substring(13,16);
      String blueString = data.substring(16,19);
      solidColor(strip.Color(redString.toInt(),greenString.toInt(),blueString.toInt()));
    }
    if(data == "Off"){
      rainbowAnimation= false;

      
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
void solidColor(float color){
  currentPixel = 0;
  while(currentPixel <= stripLength){
      strip.setPixelColor(currentPixel, color);
      strip.show();
      currentPixel ++;
    }
}


void rainbow(long wait){

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

