#include <Servo.h>
void command(char input); // Reads the input and calls the proper functions
void movement();  //sense for movement
void waveLeft();  //wave left arm
void waveRight(); //wave right arm
void wave(); //wave both arms
void armsUp();  //place arms up
void armsDown();  //place arms down
void proneLeft();     //set left arm to prone position
void proneRight();    //set right arm prone
void shakeIt();
  
#define trigPin 13
#define echoPin 12
Servo leftShoulder;
Servo leftElbow;
Servo rightShoulder;
Servo rightElbow;
boolean dance = false;

void setup() 
{ 
  Serial.begin(9600);
  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);
  //movement();
  leftShoulder.attach(11);
  leftElbow.attach(10);
  rightShoulder.attach(9);
  rightElbow.attach(8);
  proneLeft();
  proneRight();
}  

void loop(){
  char input = Serial.read();
  command(input);
}


void command(char input){
  switch(input){
    case 'a':
      waveLeft();
    break;
    case 'b':
      waveRight();
    break;
    case 'c':
      shakeIt();
    break;
    case 'd':
      wave();
    break;
    case 'e':
      int ran = random(1,4);
      if(ran == 1){
        waveLeft();
      }
      if(ran == 2){
        waveRight();
      }
      if(ran == 3){
        wave();
      }
      break;
  }
}

void movement(){
  while(true){
    long duration, distance;
    digitalWrite(trigPin, LOW);  // Added this line
    delayMicroseconds(2); // Added this line
    digitalWrite(trigPin, HIGH);
    delayMicroseconds(10); // Added this line
    digitalWrite(trigPin, LOW);
    duration = pulseIn(echoPin, HIGH);
    distance = (duration/2) / 29.1;
    if (distance < 200 && distance > 0){
      Serial.write('r'); //send reset char to serial
    }
    delay(1000);
  }
}

void proneLeft(){
  leftShoulder.write(20);
  delay(15);
  leftElbow.write(140);
  delay(15);
}

void proneRight(){
  rightShoulder.write(160);
  delay(15);
  rightElbow.write(20);
  delay(15);
}

void waveLeft(){
  for(int i=20; i<125 ; i +=2){
    leftShoulder.write(i);
    delay(15);
  }
  delay(15);
  leftElbow.write(140);
  for(int i=0;i<2;i++){
    delay(15);
    for(int angle = 60; angle < 160; angle +=3){                                  
      leftElbow.write(angle);               
      delay(15);                   
    } 
    for(int angle = 160; angle > 60; angle -=3){                                
      leftElbow.write(angle);           
      delay(15);       
    } 
  }
  proneLeft();
}

void waveRight(){
   for(int i=160; i>40 ; i -=2){
    rightShoulder.write(i);
    delay(15);
  }
  rightElbow.write(20);
  for(int i=0;i<2;i++){
    delay(15);
    for(int angle = 20; angle < 120; angle +=5){                                  
      rightElbow.write(angle);               
      delay(15);                   
    }
    for(int angle = 120; angle > 20; angle -=5){                                
      rightElbow.write(angle);           
      delay(15);       
    } 
  }
  proneRight();
}

void armsUp(){
  for(int i = 20; i<60; i +=2){
    leftShoulder.write(i);
    rightShoulder.write(180-i);
    delay(15);
  }
  delay(15);
  for(int i = 140 ; i>0; i -=2){
    leftElbow.write(i);
    rightElbow.write(180-i);
    delay(15);
  }
  delay(1500);
  for(int i = 0 ; i<140; i +=2){
    leftElbow.write(i);
    rightElbow.write(180-i);
    delay(15);
  }
  proneRight();
  proneLeft();
}
void shakeIt(){
    waveRight();
    waveLeft();
}
void wave(){
   for(int i=160; i>40 ; i -=2){
    rightShoulder.write(i);
    leftShoulder.write(180-i);
    delay(15);
  }
  rightElbow.write(20);
  leftElbow.write(140);
  for(int i=0;i<2;i++){
    delay(15);
    for(int angle = 20; angle < 120; angle +=5){                                  
      rightElbow.write(angle);
      leftElbow.write(160-angle);            
      delay(15);                   
    }
    for(int angle = 120; angle > 20; angle -=5){                                
      rightElbow.write(angle);
      leftElbow.write(160 -angle);
      delay(15);       
    } 
  }
  proneRight();
  proneLeft();
}
