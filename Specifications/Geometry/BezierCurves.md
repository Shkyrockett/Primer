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
| Linear Bézier curve | $c(t)=A(1-t)+Bt$ |
| Quadratic Bézier curve | $c(t)=A(1-t)^{2}+B2t(1-t)+Ct^{2}$ |
| Cubic Bézier curve | $c(t)=A(1-t)^{3}+B3t(1-t)^{2}+C3t^{2}(1-t)+Dt^{3}$ |
| Quartic Bézier curve| $c(t)=A(1-t)^{4}+B4t(1-t)^{3}+C6t^{2}(1-t)^{2}+D4t^{3}(1-t)+Et^{4}$ |
| Quintic Bézier curve| $c(t)=A(1-t)^{5}+B5t(1-t)^{4}+C10t^{2}(1-t)^{3}+D10t^{3}(1-t)^{2}+E5t^{4}(1-t)+Ft^{5}$ |
| Sextic Bézier curve | $c(t)=A(1-t)^{6}+B6t(1-t)^{5}+C15t^{2}(1-t)^{4}+D20t^{3}(1-t)^{3}+E15t^{4}(1-t)^{2}+F6t^{5}(1-t)+Gt^{6}$ |
| Septic Bézier curve | $c(t)=A(1-t)^{7}+B7t(1-t)^{6}+C21t^{2}(1-t)^{5}+D35t^{3}(1-t)^{4}+E35t^{4}(1-t)^{3}+F21t^{5}(1-t)^{2}+G7t^{6}(1-t)+Ht^{7}$ |
| Octic Bézier curve | $c(t)=A(1-t)^{8}+B8t(1-t)^{7}+C28t^{2}(1-t)^{6}+D56t^{3}(1-t)^{5}+E70t^{4}(1-t)^{4}+F56t^{5}(1-t)^{3}+G28t^{6}(1-t)^{2}+H8t^{7}(1-t)+It^{8}$ |
| Nonic Bézier curve | $c(t)=A(1-t)^{9}+ B9t(1-t)^{8}+C36t^{2}(1-t)^{7}+D84t^{3}(1-t)^{6}+E126t^{4}(1-t)^{5}+F126t^{5}(1-t)^{4}+G84t^{6}(1-t)^{3}+H36t^{7}(1-t)^{2}+I9t^{8}(1-t)+Jt^{9}$ |
| Decic Bézier curve | $\begin{matrix}c(t)=A(1-t)^{10}+B10t(1-t)^{9}+C45t^{2}(1-t)^{8}+D120t^{3}(1-t)^{7}+E210t^{4}(1-t)^{6}+F252t^{5}(1-t)^{5}+G210t^{6}(1-t)^{4}+G120t^{7}(1-t)^{3}+G45t^{8}(1-t)^{2}+H10t^{9}(1-t)+It^{10}\end{matrix}$ |

To make the Polynomial form of a Bézier curve: List out the Alphabetic coefficients A B C ... etc, insert (1-t) with powers decreasing from left to right. Insert t coefficients with powers decreasing from right to left. The numeric coefficients are from Pascal's Triangle for the row of the same length.

For information on how to set up the Matrix forms see: [Demofox Matrix Form of Bézier Curves](https://blog.demofox.org/2016/03/05/matrix-form-of-bezier-curves/)

## See Also

- [A Primer on Bézier Curves](https://pomax.github.io/bezierinfo/)
