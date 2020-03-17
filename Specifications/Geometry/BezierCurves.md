# Bézier Curves

- [Linear Bézier](#Linear_Bezier)
- [Quadratic Bézier](#Quadratic_Bezier)
- [Cubic Bézier](#Cubic_Bezier)
- [Quartic Bézier](#Quartic_Bezier)
- [Quintic Bézier](#Quintic_Bezier)
- [Sextic Bézier](#Sextic_Bezier)
- [Septic Bézier](#Septic_Bezier)
- [Octic Bézier](#Octic_Bezier)
- [Nonic Bézier](#Nonic_Bezier)
- [Decic Bézier](#Decic_Bezier)

## Bézier Formulas

The Polynomial form of Bézier curves.

| Name | Equation |
|---|---|
| Linear Bézier curve | $c(t) = A(1-t) + Bt$ |
| Quadratic Bézier curve | $c(t) = A(1-t)^{2} + B2t(1-t) + Ct^{2}$ |
| Cubic Bézier curve | $c(t) = A(1-t)^{3} + B3t(1-t)^{2} + C3t^{2}(1-t) + Dt^{3}$ |
| Quartic Bézier curve| $c(t) = A(1-t)^{4} + B4t(1-t)^{3} + C6t^{2}(1-t)^{2} + D4t^{3}(1-t) + Et^{4}$ |
| Quintic Bézier curve| $c(t) = A(1-t)^{5} + B5t(1-t)^{4} + C10t^{2}(1-t)^{3} + D10t^{3}(1-t)^{2} + E5t^{4}(1-t) + Ft^{5}$ |
| Sextic Bézier curve | $c(t) = A(1-t)^{6} + B6t(1-t)^{5} + C15t^{2}(1-t)^{4} + D20t^{3}(1-t)^{3} + E15t^{4}(1-t)^{2} + F6t^{5}(1-t) + Gt^{6}$ |
| Septic Bézier curve | $c(t) = A(1-t)^{7} + B7t(1-t)^{6} + C21t^{2}(1-t)^{5} + D35t^{3}(1-t)^{4} + E35t^{4}(1-t)^{3} + F21t^{5}(1-t)^{2} + G7t^{6}(1-t) + Ht^{7}$ |
| Octic Bézier curve | $c(t) = A(1-t)^{8} + B8t(1-t)^{7} + C28t^{2}(1-t)^{6} + D56t^{3}(1-t)^{5} + E70t^{4}(1-t)^{4} + F56t^{5}(1-t)^{3} + G28t^{6}(1-t)^{2} + H8t^{7}(1-t) + It^{8}$ |
| Nonic Bézier curve | $c(t) = A(1-t)^{9}+ B9t(1-t)^{8} + C36t^{2}(1-t)^{7} + D84t^{3}(1-t)^{6} + E126t^{4}(1-t)^{5} + F126t^{5}(1-t)^{4} + G84t^{6}(1-t)^{3} + H36t^{7}(1-t)^{2} + I9t^{8}(1-t) + Jt^{9}$ |
| Decic Bézier curve | $\begin{matrix}c(t) = A(1-t)^{10} + B10t(1-t)^{9} + C45t^{2}(1-t)^{8} + D120t^{3}(1-t)^{7} + E210t^{4}(1-t)^{6} + F252t^{5}(1-t)^{5} + G210t^{6}(1-t)^{4} + G120t^{7}(1-t)^{3} + G45t^{8}(1-t)^{2} + H10t^{9}(1-t) + It^{10}\end{matrix}$ |

To make the Polynomial form of a Bézier curve: List out the Alphabetic coefficients A B C ... etc, insert (1-t) with powers decreasing from left to right. Insert t coefficients with powers decreasing from right to left. The numeric coefficients are from Pascal's Triangle for the row of the same length.

## Bézier Matrix Forms

| Name | Equation |
|---|---|
| Linear Bézier Curve. Also known as a line segment. | $c(t) = \begin{bmatrix} 1 \\ (\frac{t}{2}) \end{bmatrix}\begin{bmatrix} 1 & 0 \\ -1 & 1\end{bmatrix}\begin{bmatrix} P_0\\ P_1 \end{bmatrix}$ |
| Quadratic Bézier Curve. | $c(t) = \begin{bmatrix} 1 \\ (\frac{t}{2}) \\ (\frac{t}{2})^2 \end{bmatrix} \begin{bmatrix}1 & 0 & 0 \\ -2 & 2 & 0 \\ 1 & -2 & 1 \end{bmatrix}\begin{bmatrix} P_0 \\ P_1 \\ P_2 \end{bmatrix}$ |
| Cubic Bézier Curve. | $c(t) = \begin{bmatrix} 1 \\ (\frac{t}{2}) \\ (\frac{t}{2})^2 \\ (\frac{t}{2})^3 \end{bmatrix} \begin{bmatrix} 1 & 0 & 0 & 0 \\ -3 & 3 & 0 & 0 \\ 3 & -6 & 3 & 0 \\ -1 & 3 & -3 & 1 \end{bmatrix}\begin{bmatrix} P_0 \\ P_1 \\ P_2 \\ P_3 \end{bmatrix}$ |
| Quartic Bézier Curve. | $c(t) = \begin{bmatrix} 1 \\ (\frac{t}{2}) \\ (\frac{t}{2})^2 \\ (\frac{t}{2})^3 \\ (\frac{t}{2})^4 \end{bmatrix} \begin{bmatrix} 1 & 0 & 0 & 0 & 0 \\ -4 & 4 & 0 & 0 & 0 \\ 6 & -12 & 6 & 0 & 0 \\ -4 & 12 & -12 & 4 & 0 \\ 1 & -4 & 6 & -4 & 1 \end{bmatrix}\begin{bmatrix} P_0 \\ P_1 \\ P_2 \\ P_3 \\ P_4 \end{bmatrix}$ |
| Quintic Bézier Curve. | $c(t) = \begin{bmatrix} 1 \\ (\frac{t}{2}) \\ (\frac{t}{2})^2 \\ (\frac{t}{2})^3 \\ (\frac{t}{2})^4 \\ (\frac{t}{2})^5 \end{bmatrix} \begin{bmatrix} 1 & 0 & 0 & 0 & 0 & 0 \\ -5 & 5 & 0 & 0 & 0 & 0 \\ 10 & -20 & 10 & 0 & 0 & 0 \\ -10 & 30 & -30 & 10 & 0 & 0 \\ 5 & -20 & 30 & -20 & 5 & 0 \\ -1 & 5 & -10 & 10 & -5 & 1 \end{bmatrix}\begin{bmatrix} P_0 \\ P_1 \\ P_2 \\ P_3 \\ P_4 \\ P_5 \end{bmatrix}$ |
| Sextic Bézier curve. | $c(t) = \begin{bmatrix} 1 \\ (\frac{t}{2}) \\ (\frac{t}{2})^2 \\ (\frac{t}{2})^3 \\ (\frac{t}{2})^4 \\ (\frac{t}{2})^5 \\ (\frac{t}{2})^6 \end{bmatrix} \begin{bmatrix} 1 & 0 & 0 & 0 & 0 & 0 & 0 \\ -6 & 6 & 0 & 0 & 0 & 0 & 0 \\ 15 & -30 & 15 & 0 & 0 & 0 & 0 \\ -20 & 60 & -60 & 20 & 0 & 0 & 0 \\ 15 & -60 & 90 & -60 & 15 & 0 & 0 \\ -6 & 30 & -60 & 60 & -30 & 6 & 0 \\ 1 & -6 & 15 & -20 & 15 & -6 & 1 \end{bmatrix}\begin{bmatrix} P_0 \\ P_1 \\ P_2 \\ P_3 \\ P_4 \\ P_5 \\ P_6 \end{bmatrix}$ |
| Septic Bézier curve. | $c(t) = \begin{bmatrix} 1 \\ (\frac{t}{2}) \\ (\frac{t}{2})^2 \\ (\frac{t}{2})^3 \\ (\frac{t}{2})^4 \\ (\frac{t}{2})^5 \\ (\frac{t}{2})^6 \\ (\frac{t}{2})^7 \end{bmatrix} \begin{bmatrix} 1 & 0 & 0 & 0 & 0 & 0 & 0 & 0 \\ -7 & 7 & 0 & 0 & 0 & 0 & 0 & 0 \\ 21 & -42 & 21 & 0 & 0 & 0 & 0 & 0 \\ -35 & 105 & -105 & 35 & 0 & 0 & 0 & 0 \\ 35 & -140 & 210 & -140 & 35 & 0 & 0 & 0 \\ -21 & 105 & -210 & 210 & -105 & 21 & 0 & 0 \\ 7 & -42 & 105 & -140 & 105 & -42 & 7 & 0 \\ -1 & 7 & -21 & 35 & -35 & 21 & -7 & 1 \end{bmatrix}\begin{bmatrix} P_0 \\ P_1 \\ P_2 \\ P_3 \\ P_4 \\ P_5 \\ P_6 \\ P_7 \end{bmatrix}$ |
| Octic Bézier curve. | $c(t) = \begin{bmatrix} 1 \\ (\frac{t}{2}) \\ (\frac{t}{2})^2 \\ (\frac{t}{2})^3 \\ (\frac{t}{2})^4 \\ (\frac{t}{2})^5 \\ (\frac{t}{2})^6 \\ (\frac{t}{2})^7 \\ (\frac{t}{2})^8 \end{bmatrix} \begin{bmatrix} 1 & 0 & 0 & 0 & 0 & 0 & 0 & 0 & 0 \\ -8 & 8 & 0 & 0 & 0 & 0 & 0 & 0 & 0 \\ 28 & -56 & 28 & 0 & 0 & 0 & 0 & 0 & 0 \\ -56 & 168 & -168 & 56 & 0 & 0 & 0 & 0 & 0 \\ 70 & -280 & 420 & -280 & 70 & 0 & 0 & 0 & 0 \\ -56 & 280 & -560 & 560 & -280 & 56 & 0 & 0 & 0 \\ 28 & -168 & 420 & -560 & 420 & -168 & 28 & 0 & 0 \\ -8 & 56 & -168 & 280 & -280 & 168 & -56 & 8 & 0 \\ 1 & -8 & 28 & -56 & 70 & -56 & 28 & -8 & 1 \end{bmatrix}\begin{bmatrix} P_0 \\ P_1 \\ P_2 \\ P_3 \\ P_4 \\ P_5 \\ P_6 \\ P_7 \\ P_8 \end{bmatrix}$ |
| Nonic Bézier curve. | $c(t) = \begin{bmatrix} 1 \\ (\frac{t}{2}) \\ (\frac{t}{2})^2 \\ (\frac{t}{2})^3 \\ (\frac{t}{2})^4 \\ (\frac{t}{2})^5 \\ (\frac{t}{2})^6 \\ (\frac{t}{2})^7 \\ (\frac{t}{2})^8 \\ (\frac{t}{2})^9 \end{bmatrix} \begin{bmatrix} 1 & 0 & 0 & 0 & 0 & 0 & 0 & 0 & 0 & 0 \\ -9 & 9 & 0 & 0 & 0 & 0 & 0 & 0 & 0 & 0 \\ 36 & -72 & 36 & 0 & 0 & 0 & 0 & 0 & 0 & 0 \\ -84 & 252 & -252 & 84 & 0 & 0 & 0 & 0 & 0 & 0 \\ 126 & -504 & 756 & -504 & 126 & 0 & 0 & 0 & 0 & 0 \\ -126 & 630 & -1260 & 1260 & -630 & 126 & 0 & 0 & 0 & 0 \\ 84 & -504 & 1260 & -1680 & 1260 & -504 & 84 & 0 & 0 & 0 \\ -36 & 252 & -756 & 1260 & -1260 & 756 & -252 & 36 & 0 & 0 \\ 9 & -72 & 252 & -504 & 630 & -504 & 252 & -72 & 9 & 0 \\ -1 & 9 & -36 & 84 & -126 & 126 & -84 & 36 & -9 & 1 \end{bmatrix}\begin{bmatrix} P_0 \\ P_1 \\ P_2 \\ P_3 \\ P_4 \\ P_5 \\ P_6 \\ P_7 \\ P_8 \\ P_9 \end{bmatrix}$ |
| Decic Bézier curve. | $\begin{matrix}c(t)=\begin{bmatrix}1\\(\frac{t}{2})\\(\frac{t}{2})^2\\(\frac{t}{2})^3\\(\frac{t}{2})^4\\(\frac{t}{2})^5\\(\frac{t}{2})^6\\(\frac{t}{2})^7\\(\frac{t}{2})^8\\(\frac{t}{2})^9\\(\frac{t}{2})^{10}\end{bmatrix} \begin{bmatrix} 1 & 0 & 0 & 0 & 0 & 0 & 0 & 0 & 0 & 0 & 0 \\ -10 & 10 & 0 & 0 & 0 & 0 & 0 & 0 & 0 & 0 & 0 \\ 45 & -90 & 45 & 0 & 0 & 0 & 0 & 0 & 0 & 0 & 0 \\ -120 & 360 & -360 & 120 & 0 & 0 & 0 & 0 & 0 & 0 & 0 \\ 210 & -840 & 1260 & -840 & 210 & 0 & 0 & 0 & 0 & 0 & 0 \\ -252 & 1260 & -2520 & 2520 & -1260 & 252 & 0 & 0 & 0 & 0 & 0 \\ 210 & -1260 & 3150 & -4200 & 3150 & -1260 & 210 & 0 & 0 & 0 & 0 \\ -120 & 840 & -2520 & 4200 & -4200 & 2520 & -840 & 120 & 0 & 0 & 0 \\ 45 & -360 & 1260 & -2520 & 3150 & -2520 & 1260 & -360 & 45 & 0 & 0 \\ -10 & 90 & -360 & 840 & -1260 & 1260 & -840 & 360 & -90 & 10 & 0 \\ 1 & -10 & 45 & -120 & 210 & -252 & 210 & -120 & 45 & -10 & 1 \end{bmatrix}\begin{bmatrix} P_0\\P_1\\P_2\\P_3\\P_4\\P_5\\P_6\\P_7\\P_8\\P_9\\P_{10} \end{bmatrix}\end{matrix}$ |

For information on how to set up the Matrix forms see: [Demofox Matrix Form of Bézier Curves](https://blog.demofox.org/2016/03/05/matrix-form-of-bezier-curves/)

## See Also

- [A Primer on Bézier Curves](https://pomax.github.io/bezierinfo/)
