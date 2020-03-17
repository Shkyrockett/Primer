# Mathematics in Coding

## Converting Mathematical Notation Into Code

Numbers in computers do not act the same way as they are supposed to in mathematics. In mathematics every number is a number, and between every number is a Number, and this goes off infinitely.  
But in computers numbers are limited to the kind of number you use.  

You have number types that can only be integers, others that are only positive integers. There are some that can do the numbers between numbers, and even some that are specifically designed to mimic decimal numbers. Even crazier there are numbers that are only true or false.  

Unlike theoretical math, all of the number systems/types in computers have upper and lower bound limits. For instance the most common integer types generally increase in the number of numbers they can represent by powers of two.  

This means that you need to pay attention to your order of operations in some cases to prevent the numbers from overflowing and possibly wrapping around. Which computer numbers can indeed do.

An example from the Wikipedia article in [linear interpolation](https://en.wikipedia.org/wiki/Linear_interpolation):

```csharp
// Imprecise method, which does not guarantee return = b when t = 1, due to floating-point arithmetic error.
// This form may be used when the hardware has a native fused multiply-add instruction.
float lerp(float a, float b, float t) {
  return a + t * (b - a);
}

// Precise method, which guarantees return = b when t = 1.
float lerp(float a, float b, float t) {
  return (1 - t) * a + t * b;
}
```

When it comes to number types that have decimals, or floating points, the precision that can be represented can decrease the larger the number is, and eventually starts skipping numbers that it can't represent.  
Learn more in the PBS Infinite Series: Why Computers are Bad at Algebra.

> [![Why Computers are Bad at Algebra | Infinite Series](http://img.youtube.com/vi/pQs_wx8eoQ8/0.jpg)](https://www.youtube.com/embed/pQs_wx8eoQ8 "Why Computers are Bad at Algebra | Infinite Series")  
> Why Computers are Bad at Algebra | Infinite Series

## On Pi in Floats and Doubles

float and double are binary-based floating-point numbers and aren't actually able to represent any value that has 17 digits exactly, instead they get an approximation that is "close enough" for most purposes.

Under the hood, binary-based floating point numbers are constructed out of a sign, exponent, and significand. You can then compute the actual underlying value using the algorithm: $-1^{sign}$  $2^{exponent}$ significand. This blog post by Fabien Sanglard actually does a good job of explaining this in terms of the exponent being a window and the significand being an offset into that window: <http://fabiensanglard.net/floating_point_visually_explained/>

Each "window" covers the next power of $2$ (since these are binary-based), so one window is $[0.5,1]$, the next window is $[1,2]$, then $[2,4]$, etc. Each window is then evenly divided by the number of available offsets. This means that values that fall into the $[1,2]$ window are more precise then values that fall into the $[2,4]$ window.

PI falls into the $[2,4]$ window and since double has a 52-bit significand you have $2^{52}$ ($4,503,599,627,370,496$) evenly space values that have a delta of $4.4408920985006261616945266723633e-16$. For float, you have a 23-bit signficand, so you have $2^{23}$ ($8,388,608$) evenly spaced values that have a delta of $2.384185791015625e-7$.

Given the above, you would find that PI is not exactly representable and the value chosen is the closest representable value.

* Wikipedia says PI to 50 digits is: $3.14159265358979323846264338327950288419716939937510...$

* We say the closest representable value is: $3.141592653589793115997963468544185161590576171875$
  * The raw bit representation is: $0x400921FB54442D18$
  * This is $1.224646799147353177226065932275001$ × $10^{-16}$ less than 50 digit PI
* The next highest representable value is: $3.141592653589793560087173318606801331043243408203125$
  * The raw bit representation is: $0x400921FB54442D19$
  * This is $3.21624529935327298446846074008828025$ × $10^{-16}$ greater than 50 digit PI
* The next lowest representable value is: $3.141592653589792671908753618481568992137908935546875$
  * The raw bit representation is: $0x400921FB54442D17$
  * This is $5.66553889764797933892059260463828225$ × $10^{-16}$ less than 50 digit PI

[Tanner Gooding - Floating-Point Parsing and Formatting improvements in .NET Core 3.0](https://devblogs.microsoft.com/dotnet/floating-point-parsing-and-formatting-improvements-in-net-core-3-0/#comments-1211)
