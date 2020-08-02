# Conic Sections

## General Conics Equations

Different sources may use different representations for $A$ $B$ $C$ $D$ $E$ $F$ form of Conics:

| Equation | Description |
|---|---|
| $Ax^2+B\color{red}{xy}+C\color{red}{y^2}+Dx+Ey+F=0$ | General Conics Equasion. This is a reduced form of the Homogeneous coordinats conic equasion where $z=1$. |
| $Ax^2+B\color{red}{y^2}+C\color{red}{xy}+Dx+Ey+F=0$ | General Conics Equasion with $xy$ and $y^2$ swaped. |
| $Ax^2+B\color{red}{xy}+C\color{red}{y^2}+Dx\color{blue}{z}+Ey\color{blue}{z}+F\color{blue}{z^2}=0$ | Homogeneous coordinates a conic section. |

You have to be alert to which form is being used.

## Types of Conics

### Standard Forms of Conics

| Conic Shape | General Form | Standard Form |  |
|---|---|---|---|---|
| **[Circles](#Circles)** | $x^2+y^2+Dx+Ey+F=0$ | $(x-h)^2+(y-k)^2=r^2$, $x2+y2=r2$ |  |
| **[Ellipses](#Ellipses)** | $Ax^2+Cy^2+Dx+Ey+F=0$ | $\frac{(x-h)^2}{a^2}+\frac{(y-k)^2}{b^2}=1$ | $?$ |
| **[Parabolas](#Parabolas)** | $Ax^2+Dx+Ey=0$ | $?$ | $?$ |
| **[Hyperbolas](#Hyperbolas)** | $Ax^2-Cy^2+Dx+Ey+F=0$ | $\frac{x^2}{a^2}-\frac{y^2}{b^2}=1$, $\frac{(x-h)^2}{a^2}-\frac{(y-k)^2}{b^2}=1$, $\frac{((x-h)\cos{(\alpha)}+(y-k)\sin{(\alpha)})^2}{a^2}-\frac{((x-h)\sin{(\alpha)}-(y-k)\cos{(\alpha)})^2}{b^2}=1$ | $$ |
| **[Rectangular Hyperbolas](#RectangularHyperbolas)** | $?$ | $?$ | $?$ |

- [Conics Table](https://www.purplemath.com/modules/conics.htm)
- [Conics Information](https://www.intmath.com/plane-analytic-geometry/conic-sections-summary.php)

### Degenerate Forms of Conics

| Conic Shape | General Form | Standard Form |  |
|---|---|---|---|---|
| **[Points](#Points)** | $?$ | $\frac{(x-h)^2}{a}+\frac{(y-k)^2}{b}=0$ | $?$ |
| **[Lines](#Lines)** | $Dx+Ey+F=0, A=B=C=0$ | $?$ | $?$ |
| **[Parallel Lines](#Parallels)** | $?$ | $?$ | $?$ |
| **[Crosses](#Crosses)** | $?$ | $\frac{(x-h)^2}{a}-\frac{(y-k)^2}{b}=1$ | $?$ |

- [Degenerate Conics](https://www.ck12.org/book/ck-12-college-precalculus/section/11.7/)

## Matrix Form

$Ax^2+B\color{red}{xy}+C\color{red}{y^2}+Dx+Ey+F=0$

The above equation can be written in matrix notation as:

$\begin{pmatrix}x&y\end{pmatrix}\begin{pmatrix}A&\frac{B}{2}\\\frac{B}{2}&C\end{pmatrix}\begin{pmatrix}x\\y\end{pmatrix}+\begin{pmatrix}D&E\end{pmatrix}\begin{pmatrix}x\\y\end{pmatrix}+F=0$

The general equation can also be written as:

$\begin{pmatrix}x&y&1\end{pmatrix}\begin{pmatrix}A&\frac{B}{2}&\frac{D}{2}\\\frac{B}{2}&C&\frac{E}{2}\\\frac{D}{2}&\frac{E}{2}&F\end{pmatrix}\begin{pmatrix}x\\y\\1\end{pmatrix}=0$

- See: [Wikipedia: Conic Section #General Cartesian form](https://en.wikipedia.org/wiki/Conic_section#General_Cartesian_form)

## Homogeneous Coordinates

In homogeneous coordinates a conic section can be represented as:

$Ax^2+B\color{red}{xy}+C\color{red}{y^2}+Dx\color{blue}{z}+Ey\color{blue}{z}+F\color{blue}{z^2}=0$

Or in matrix notation, the 3 × 3 matrix of the conic section is:

$\begin{pmatrix}x&y&z\end{pmatrix}\begin{pmatrix}A&\frac{B}{2}&\frac{D}{2}\\\frac{B}{2}&C&\frac{E}{2}\\\frac{D}{2}&\frac{E}{2}&F\end{pmatrix}\begin{pmatrix}x\\y\\z\end{pmatrix}=0$

Some authors prefer to write the general homogeneous equation as below so that the matrix of the conic section has the simpler form:

$Ax^2+2B\color{red}{xy}+C\color{red}{y^2}+2Dx\color{blue}{z}+2Ey\color{blue}{z}+F\color{blue}{z^2}=0$

$M=\begin{pmatrix}A&B&D\\B&C&E\\D&E&F\end{pmatrix}$

If the determinant of the matrix of the conic section is zero, the conic section is degenerate.

- See: [Wikipedia: Conic Section #In the real projective plane](https://en.wikipedia.org/wiki/Conic_section#In_the_real_projective_plane)

## Points

## Circles

<center>
<svg width="260" height="210">
 <defs>
  <marker orient="auto" markerHeight="20" markerWidth="20" markerUnits="strokeWidth" refY="3" refX="0" viewBox="0 0 20 20" fill="black" id="arrow">
    <path d="m0,0l0,6l9,-3l-9,-3z" id="Triangle"/>
  </marker>
 </defs>
 <g stroke-width="1" stroke="black" fill="transparent">
  <circle cx="105" cy="105" r="100" id="Circle"/>
  <circle cx="105" cy="105" r="3" fill="black" id="Center"/>
  <line x1="140" y1="5" x2="256" y2="5" id="Diameter Top"/>
  <line x1="140" y1="205" x2="256" y2="205" id="Diameter Bottom"/>
  <line x1="105" y1="105" x2="205" y2="105" id="Radius Horizontal"/>
  <line x1="105" y1="105" x2="185" y2="45" id="Radius Hypotenuse"/>
  <circle cx="185" cy="45" r="3" fill="black" id="Point"/>
  <g marker-end="url(#arrow)">
 <line x1="105" y1="45" x2="105" y2="12" id="Radius 1"/>
 <line x1="105" y1="70" x2="105" y2="95" id="Radius 2"/>
 <line x1="250" y1="95" x2="250" y2="15" id="Diameter 1"/>
 <line x1="250" y1="125" x2="250" y2="195" id="Diameter 2"/>
 <line x1="155" y1="45" x2="175" y2="45" id="Cos 1"/>
 <line x1="155" y1="45" x2="115" y2="45" id="Cos 2"/>
 <line x1="185" y1="65" x2="185" y2="55" id="Sin 1"/>
 <line x1="185" y1="85" x2="185" y2="95" id="Sin 2"/>
  </g>
 </g>
 <g fill="black" font-family="san-serif" font-size="14">
  <text x="105" y="62" text-anchor="middle" id="Radius Letter">r</text>
  <text x="110" y="120" text-anchor="left" id="Center Letter">c (a, b)</text>
  <text x="190" y="40" text-anchor="left" id="Point Letter">p (x, y)</text>
  <text x="250" y="115" text-anchor="middle" id="Diameter Letter">d</text>
  <text x="185" y="185" text-anchor="middle" id="Circumference Letter">C</text>
  <text x="75" y="155" text-anchor="middle" id="Area Letter">A</text>
  <text x="125" y="40" text-anchor="left" id="Cos Letter">rCos(θ)</text>
  <text x="155" y="80" text-anchor="left" id="Sin Letter">rSin(θ)</text>
 </g>
</svg>
</center>

| Function | Name | Description |
|:---:|---|---|
| $x^2+y^2=r^2$ | Simple equation of the Circle. | The simple form definition of a circle. |
| $(x-a)^2+(y-b)^2=r^2$ | Equation of the Circle. | The expanded equation of the Circle. |
| $\begin{matrix}r^2-2rr_0\cos{(\theta-\phi)}+r^2=a^2\end{matrix}$ | Equation of the Circle in polar form. | The equation of a Circle in Polar form. |
| $x=a+r\cos{\theta}$ | Circle in parametric form for x. | The equation of a Circle in parametric form solving for x. |
| $y=b+r\sin{\theta}$ | Circle in parametric form for y. | The equation of a Circle in parametric form solving for y. |
| $x=a+r\frac{2\theta}{1+\theta^2}$ | Alternative circle in parametric form for x. | An alternative equation of a Circle in parametric form solving for x. |
| $y=b+r\frac{1-\theta^2}{1+\theta^2}$ | Alternative circle in parametric form for y. | An alternative equation of a Circle in parametric form solving for y. |
| $C=2\pi r$ | Circumference. | The circumference of a circle from it's radius. |
| $C=\pi d$ | Circumference. | The circumference of a circle from it's diameter. |
| $A=\pi r^2$ | Area. | Area of a circle from it's radius. |
| $A=\frac{\pi d^2}{4}$ | Area. | Area of a circle from it's diameter. |
| $\begin{matrix}r-2a\cos{(\theta-\phi)}\pm\sqrt{a^2-r_0^2\sin^2{(\theta-\phi)}}\end{matrix}$ | Radius. | Solve for the radius in polar coordinates. |
| $\begin{matrix}(x_1-a)x+(y_1-b)y=(x_1-a)x_1+(y_1-b)y_1\end{matrix}$ | Tangent form. | An equation for the tangent of the circle. |
| $(x_1-a)(x-a)+(y_1-b)(y-b)=r^2$ | Tangent form. | Another equation for the tangent of the circle. |
| $\frac{dy}{dx}=\frac{x_1-a}{y_1-b},y_1\ne b$ | Slope. | The slope of the tangent line of the circle. |

### Ellipses

<center>
<svg width="260" height="260">
 <defs>
  <marker orient="auto" markerHeight="20" markerWidth="20" markerUnits="strokeWidth" refY="3" refX="0" viewBox="0 0 20 20" fill="black" id="arrow">
<path d="m0,0l0,6l9,-3l-9,-3z" id="Triangle"/>
  </marker>
 </defs>
 <g stroke-width="1" stroke="black" fill="transparent"  transform="translate(0 30) rotate(-45 105 105)">
  <ellipse cx="105" cy="105" rx="100" ry="50" id="Ellipse"/>
  <circle cx="105" cy="105" r="3" fill="black" id="Center"/>
  <circle cx="150" cy="60" r="3" fill="black" id="Point"/>
  <circle cx="35" cy="105" r="3" fill="black" id="Foci 1"/>
  <circle cx="175" cy="105" r="3" fill="black" id="Foci 2"/>
  <line x1="5" y1="120" x2="5" y2="180" id="Diameter Left"/>
  <line x1="205" y1="120" x2="205" y2="180" id="Diameter Right"/>
  <line x1="145" y1="55" x2="240" y2="55" id="Diameter Top"/>
  <line x1="145" y1="155" x2="240" y2="155" id="Diameter Bottom"/>
  <line x1="35" y1="105" x2="35" y2="30" id="Focus Left"/>
  <line x1="105" y1="55" x2="105" y2="30" id="Focus Right"/>
  <line x1="105" y1="105" x2="150" y2="60" id="Hyp"/>
  <line x1="105" y1="105" x2="170" y2="170" stroke-dasharray="2px, 2px" id="Angle Start"/>
  <path d="m125,105 a20,20 0 0 1 -5.85786,14.14214" id="Cos Angle" />
  <g marker-end="url(#arrow)">
 <line x1="105" y1="74" x2="105" y2="65" id="Radius a1"/>
 <line x1="105" y1="88" x2="105" y2="95" id="Radius a2"/>
 <line x1="163" y1="105" x2="195" y2="105" id="Radius b1"/>
 <line x1="145" y1="105" x2="115" y2="105" id="Radius b2"/>
 <line x1="235" y1="115" x2="235" y2="145" id="Diameter a1"/>
 <line x1="235" y1="95" x2="235" y2="65" id="Diameter a2"/>
 <line x1="120" y1="175" x2="195" y2="175" id="Diameter b1"/>
 <line x1="90" y1="175" x2="15" y2="175" id="Diameter b2"/>
 <line x1="80" y1="35" x2="95" y2="35" id="Focus 1"/>
 <line x1="60" y1="35" x2="45" y2="35" id="Focus 2"/>
  </g>
 </g>
 <g fill="black" font-family="san-serif" font-size="14">
  <text x="88" y="120" text-anchor="middle" id="Radius Letter">a</text>
  <text x="140" y="105" text-anchor="middle" id="Radius Letter">b</text>
  <text x="110" y="150" text-anchor="left" id="Center Letter">o (h, k)</text>
  <text x="60" y="60" text-anchor="left" id="Point Letter">p (x, y)</text>
  <text x="195" y="45" text-anchor="middle" id="Diameter Letter">dₖ</text>
  <text x="155" y="187" text-anchor="middle" id="Diameter Letter">dₕ</text>
  <text x="90" y="225" text-anchor="middle" id="Circumference Letter">C</text>
  <text x="90" y="175" text-anchor="middle" id="Area Letter">A</text>
  <text x="130" y="128" text-anchor="middle" id="Area Letter">α</text>
  <text x="65" y="175" text-anchor="middle" id="Area Letter">f₁</text>
  <text x="145" y="80" text-anchor="middle" id="Area Letter">f₂</text>
  <text x="30" y="115" text-anchor="middle" id="Area Letter">f</text>
 </g>
</svg>
</center>

| Function | Name | Description |
|:---:|---|---|
| $\frac{x^2}{a^2}+\frac{y^2}{b^2}=1$ | Ellipse Equation, Standard form. | The equation of an ellipse whose major and minor axes coincide with the Cartesian axes. |
| $\frac{(x-h)^2}{a^2}+\frac{(y-k)^2}{b^2}=1$ | Translated Ellipse Equation, Standard form. | The equation of an ellipse that has been Translated away from the Origin. Where h, and k are the new center point. |
| $\frac{((x-h)\cos{(\alpha)}+(y-k)\sin{(\alpha)})^2}{a^2}+\frac{((x-h)\sin{(\alpha)}-(y-k)\cos{(\alpha)})^2}{b^2}=1$ | Rotated and Translated Ellipse Equation, Standard form. | The equation of an ellipse that has been Translated away from the Origin, and rotated. Where h, and k are the new center point, and α is the angle of rotation. |
| $y=\frac{\pm\frac{\sqrt{2}\sqrt{a^2\cos{2\alpha}+a^2-b^2\cos{2\alpha}+b^2-2h^2+4hx-2x^2}}{ab}+\frac{2h\sin{\alpha}\cos{\alpha}}{a^2}+\frac{2k\sin^2{\alpha}}{a^2}-\frac{2x\sin{\alpha}\cos{\alpha}}{a^2}-\frac{2h\sin{\alpha}\cos{\alpha}}{b^2}+\frac{2k\cos^2{\alpha}}{b^2}+\frac{2x\sin{\alpha}\cos{\alpha}}{b^2}}{2(\frac{\sin^2{\alpha}}{a^2}+\frac{\cos^2{\alpha}}{b^2})}$ | Cartesian solution for y of rotated ellipse. |  |
| $x=\frac{\pm\frac{\sqrt{2}\sqrt{a^2(-\cos{2\alpha})+a^2+b^2\cos{2\alpha}+b^2-2k^2+4ky-2y^2}}{ab}+\frac{2h\cos^2{\alpha}}{a^2}+\frac{2k\sin{\alpha}\cos{\alpha}}{a^2}-\frac{2y\sin{\alpha}\cos{\alpha}}{a^2}+\frac{2h\sin^2{\alpha}}{b^2}-\frac{2k\sin{\alpha}\cos{\alpha}}{b^2}+\frac{2y\sin{\alpha}\cos{\alpha}}{b^2}}{2(\frac{\cos^2{\alpha}}{a^2}+\frac{\sin^2{\alpha}}{b^2})}$ | Cartesian solution for x of rotated ellipse. |  |
| $x=a\cos{(\alpha)}$ | Parametric form of ellipse for x. |  |
| $y=b\sin{(\alpha)}$ | Parametric form of ellipse for y. |  |
| $x=h+a\cos{(\phi)}\cos{(\theta)}-b\sin{(\phi)}\sin{(\theta)}$ | Parametric form of rotated and translated ellipse for x. |  |
| $y=k+a\sin{(\phi)}\cos{(theta)}+b\cos{(\phi)}\sin{(\theta)}$ | Parametric form of rotated and translated ellipse for y. |  |
| $f=\sqrt{a^2-b^2}$ | focus | The focus distance of the ellipse from the axi. |
| $\varepsilon=\sqrt{\frac{a^2-b^2}{a^2}}$ | eccentricity. | The eccentricity of the ellipse. |
| $\varepsilon=\sqrt{1-(\frac{b^2}{a})}$ | eccentricity. | The eccentricity of the ellipse. |
| $\varepsilon=\frac{f}{a}$ | eccentricity. | The eccentricity of the ellipse. |
| $\varepsilon=\frac{Pf}{PD}$ | eccentricity. | The eccentricity of the ellipse. |
| $A=\pi ab$ | area. | The area of an ellipse. |
| $\begin{matrix}C=4aE(\varepsilon),\varepsilon=\left({\sqrt{1-(\frac{b}{a})^2}}\right),E(\varepsilon)=\int_{0}^{\frac{\pi}{2}}\sqrt{1-\varepsilon^2\sin^2{(\theta)}}d\theta\end{matrix}$ | circumference. | The circumference of an ellipse. |
| ... | ... | ... |
| $k=\frac{1}{a^2b^2}\left(\frac{x^2}{a^2}+\frac{y^2}{b^2}\right)^{-\frac{3}{2}}$ | curvature. | The curvature of an ellipse. |

#### Ellipses and Conics

[General conic formula:](https://en.wikipedia.org/wiki/Ellipse#General_ellipse)

$Ax^2+B\color{red}{xy}+C\color{red}{y^2}+Dx+Ey+F=0$

$A=a^2\sin^2{\theta}+b^2\cos^2{\theta}$  
$B=2(b^2-a^2)\sin{\theta}\cos{\theta}$  
$C=a^2\cos^2{\theta}+b^2\sin^2{\theta}$  
$D=-2Ah-Bk$  
$E=-Bh-2Ck$  
$F=Ah^2+Bhk+Ck^2-a^2b^2$  

Orthogonal reduces down to:

$A=b^2$  
$B=0$  
$C=a^2$  
$D=-2hb^2$  
$E=-2ka^2$  
$F=h^2b^2+k^2a^2-a^2b^2$  

[Ellipse Relationship to Conics](https://math.stackexchange.com/a/2989928)  
$Ax^2+B\color{red}{y^2}+C\color{red}{xy}+Dx+Ey+F=0$

relates to ellipse $h$, $k$, $a$, $b$, $\theta$ with the following:

$A=\frac{\cos^2{(\theta)}}{a^2}+\frac{\sin^2{(\theta)}}{b^2}$  
$B=\frac{\sin^2{(\theta)}}{a^2}+\frac{\cos^2{(\theta)}}{b^2}$  
$C=\frac{\sin{(2\theta)}}{a^2}-\frac{\sin{(2\theta)}}{b^2}$  
$D=-\frac{2h\cos^2(\theta)}{a^2}-\frac{k\sin(2\theta)}{a^2}-\frac{2h\sin^2(\theta)}{b^2}+\frac{k\sin(2\theta)}{b^2}$  
$E=-\frac{h\sin(2\theta)}{a^2}-\frac{2k\sin^2(\theta)}{a^2}+\frac{h\sin(2\theta)}{b^2}-\frac{2k\cos^2(\theta)}{b^2}$  
$F=\frac{h^2\cos^2(\theta)}{a^2}+\frac{hk\sin(2\theta)}{a^2}+\frac{k^2\sin^2(\theta)}{a^2}+\frac{h^2\sin^2(\theta)}{b^2}-\frac{hk\sin(2\theta)}{b^2}+\frac{k^2\cos^2(\theta)}{b^2}-1$

## Parabolas

<center>
<svg width="260" height="210">
  <defs>
    <marker orient="auto" markerHeight="20" markerWidth="20" markerUnits="strokeWidth" refY="3" refX="0" viewBox="0 0 20 20" fill="black" id="arrow">
      <path d="m0,0l0,6l9,-3l-9,-3z" id="Triangle"/>
    </marker>
  </defs>
  <g stroke-width="1" stroke="black" fill="transparent">
    <path d="M 0,0 Q 105,310 210,0" id="Parabola"/>
    <circle cx="105" cy="155" r="3" fill="black" id="Vertex"/>
    <circle cx="105" cy="137" r="3" fill="black" id="Focus"/>
    <circle cx="168" cy="100" r="3" fill="black" id="Point"/>
    <g stroke-dasharray="8,4,2,4">
      <line x1="105" y1="0" x2="105" y2="10" id="Axis of Symmetry 1"/>
      <line x1="105" y1="32" x2="105" y2="210" id="Axis of Symmetry 2"/>
    </g>
    <line x1="70" y1="137" x2="140" y2="137" id="Latus Rectum"/>
    <line x1="0" y1="173" x2="260" y2="173" stroke-dasharray="2px, 2px" id="Directrix"/>
    <line x1="105" y1="137" x2="168" y2="100" id="Distance 1"/>
    <line x1="168" y1="100" x2="168" y2="173" id="Distance 2"/>
    <line x1="168" y1="60" x2="168" y2="90" id="Distance Right"/>
    <circle cx="168" cy="100" r="73" id="Dist"/>
    <circle cx="105" cy="155" r="18" id="Vert"/>
    <line x1="105" y1="155" x2="114" y2="171" id="a radius"/>
    <g marker-end="url(#arrow)">
      <line x1="145" y1="65" x2="158" y2="65" id="T 1"/>
      <line x1="130" y1="65" x2="115" y2="65" id="T 2"/>
      <line x1="130" y1="190" x2="120" y2="178" id="a radius"/>
    </g>
    <rect x="168" y="163" width="10" height="10" id="Square"/>
  </g>
  <g fill="black" font-family="san-serif" font-size="14">
    <text x="210" y="188" text-anchor="left" id="Directrix Text">Directrix</text>
    <text x="48" y="158" text-anchor="middle" id="Vertex Text">Vertex (h, k)</text>
    <text x="69" y="115" text-anchor="left" id="Focus Text">Focus (h, a)</text>
    <text x="135" y="68" text-anchor="left" id="Focus Text">x</text>
    <text x="187" y="140" text-anchor="middle" id="Latus Rectum Text">Latus Rectum</text>
    <text x="105" y="25" text-anchor="middle" id="Axis of Symmetry Text">Axis of Symmetry</text>
    <text x="175" y="102" text-anchor="left" id="Point Letter">p (x, y)</text>
    <text x="135" y="194" text-anchor="middle" id="Letter 1">a</text>
  </g>
</svg>
</center>

| Function | Description |
|---|---|
| $y=a(x-h)^2+k$ | General vertex form of a parabola. $(h, k)$ is the vertex. |
| $y=a(x+\frac{b}{2a})^2-\frac{b^2}{4a}+c$ | Intermediate standard form using vertex form variables. |
| $-x\sin{\theta}+y\cos{\theta}=a\left(x\cos{\theta}+y\sin{\theta}-h\right)^2+k$ |  |
| $y=ax^2 + bx + c$ | Standard form of a parabola. |
| $y=x(ax+b)+c$ | Alternate standard form if all variables are positive. |
| $a=\frac{y-bx-c}{x^2}$ | Find $a$ from the standard form. |
| $a=\frac{y-k}{(x-h)^2}$ | Find $a$ from vertex form. |
| $b=-2ah$ | Find $b$ in the standard form from the vertex form. |
| $c=\frac{b^2}{4a}+k$ | Find $c$ in the standard form from the vertex form. |
| $h=-\frac{b}{2a}$ | Find vertex form $h$ from the standard form. |
| $h=\sqrt{\frac{y-k}{a}}+x$ | Find $h$ from the vertex form. |
| $k=-\frac{b^2}{4a}+c$ | Find vertex form $k$ from the standard form. |
| $k=y-a(x-h)^2$ | Find $k$ from vertex form. |
| $x=\frac{-b+\sqrt{b^2+4ac}}{2a}$ <br/> $x=\frac{-b-\sqrt{b^2+4ac}}{2a}$ | x-intercept of standard form. |
| $y=c$? | y-intercept of standard form. |
| $d=k-a$? | Find the Directrix. |

$A(x\cos{\theta}-y\sin{\theta})^2+B(x\cos{\theta}-y\sin{\theta})(x\sin{\theta}+y\cos{\theta})+C(x\sin{\theta}+y\cos{\theta})^2+D(x\cos{\theta}-y\sin{\theta})+E(x\sin{\theta}+y\cos{\theta})+F=0$

$-x\sin{\theta}+y\cos{\theta}=a\left(x\cos{\theta}+y\sin{\theta}-h\right)^{2}+k$

$-x\sin{\theta}+y\cos{\theta}=a(x\cos{\theta}-y\sin{\theta})^2+bx+c$

$x^2-2xy+y^2-x\sqrt{2}-y\sqrt{2}=0$

$b2x^2-2abxy+a^2y^2-2bcax-2b^2cy=(bc)^2$

$b^2(x-h)^2-2ab(x-h)(y-k)+a^2(y-k)^2-2bca(x-h)-2b^2c(y-k)=(bc)^2$

$y=-\frac{\csc^2{t}\sqrt{4ah\sin{2t}+4ak\cos{2t}-4ak-8ax\sin{t}+\cos{2t}+1}}{\sqrt{2}}+2ah\csc{t}-2ax\cot{t}+\frac{\cot{t}\csc{t})}{2a}$

$y=-\frac{\sqrt{4ah2\sin{t}\cos{t}-4ak\sin^{2}{t}-\sin^{2}{t}-4ak-8ax\sin{t}+4ak\cos^{2}{t}+\cos^{2}{t}+1}}{\sin^2{t}\sqrt{2}}+\frac{2ah}{\sin{t}}-\frac{2ax\cos{t}}{\sin{t}}+\frac{\cos{t}}{2a\sin^2{t}}$

## Solving for $h$ given $p_1(x_1, y_1)$, $p_2(x_2, y_2)$, and $k$ from $(h, k)$

Start with the formula for a parabola in general vertex form.

$y=a(x-h)^2+k$

Move $k$ over with by subtracting both sides.

$y-k=a(x-h)^2$

Divide $y-k$ by $(x-h)^2$ to isolate $a$.

$a=\frac{y-k}{(x-h)^2}$

Set up to do for $a_1$ and $a_2$ using $x_1$, $y_1$, $x_2$, $y_2$ and $k$.

$a_1=\frac{y_1-k}{(x_1-h)^2}$

$a_2=\frac{y_2-k}{(x_2-h)^2}$

Make $a_1$ equal $a_2$.

$\frac{y_1-k}{(x_1-h)^2}=\frac{y_2-k}{(x_2-h)^2}$

Multiply both sides by the denominators to eliminate the division.

$(y_1-k)(x_2-h)^2=(y_2-k)(x_1-h)^2$

Divide both sides by $y_1-k$ to move it to the right side.

$(x_2-h)^2=\frac{(y_2-k)}{(y_1-k)}(x_1-h)^2$

Expand the squares.

$h^2-2hx_2+x_2^2=\frac{(y_2-k)}{(y_1-k)}(h^2-2hx_1+x_1^2)$

Distribute the fraction.

$h^2-2hx_2+x_2^2=h^2\frac{(y_2-k)}{(y_1-k)}-2hx_1\frac{(y_2-k)}{(y_1-k)}+x_1^2\frac{(y_2-k)}{(y_1-k)}$

Rearrange terms.

$0=h^2-h^2\frac{(y_2-k)}{(y_1-k)}-2hx_2+2hx_1\frac{(y_2-k)}{(y_1-k)}+x_2^2-x_1^2\frac{(y_2-k)}{(y_1-k)}$

Group like terms.

$0=\left(h^2-h^2\frac{(y_2-k)}{(y_1-k)}\right)-\left(2hx_2+2hx_1\frac{(y_2-k)}{(y_1-k)}\right)+\left(x_2^2-x_1^2\frac{(y_2-k)}{(y_1-k)}\right)$

Extract the $h$ values.

$0=h^2\left(1-\frac{y_2-k}{y_1-k}\right)-h\left(2x_2+2x_1\frac{y_2-k}{y_1-k}\right)+\left(x_2^2-x_1^2\frac{y_2-k}{y_1-k}\right)$

Locate $a$, $b$, and $c$ terms.

$0=h^2\left(1-\frac{y_2-k}{y_1-k}\right)_{[a]}-h\left(2x_2+2x_1\frac{y_2-k}{y_1-k}\right)_{[b]}+\left(x_2^2-x_1^2\frac{y_2-k)}{y_1-k}\right)_{[c]}$

Set up the quadratic formula.

$h=\frac{-[b]\pm\sqrt{[b]^2+4[a][c]}}{2[a]}$

substitute $[a]$, $[b]$, and $[c]$ terms into the quadratic formula.

$h=\frac{\left(2x_2+2x_1\frac{y_2-k}{y_1-k}\right)\pm\sqrt{\left(2x_2+2x_1\frac{y_2-k}{y_1-k}\right)^2+4\left(1-\frac{y_2-k}{y_1-k}\right)\left(x_2^2-x_1^2\frac{y_2-k)}{y_1-k}\right)}}{2\left(1-\frac{y_2-k}{y_1-k}\right)}$

Simplify.

$h=\frac{2x_2+2x_1\frac{y_2-k}{y_1-k}\pm\sqrt{\left(2x_2+2x_1\frac{y_2-k}{y_1-k}\right)^2+4\left(1-\frac{y_2-k}{y_1-k}\right)\left(x_2^2-x_1^2\frac{y_2-k)}{y_1-k}\right)}}{2-2\frac{y_2-k}{y_1-k}}$

## See Also

[![Extraordinary Conics: The Most Difficult Math Problem I Ever Solved](http://img.youtube.com/vi/X83vac2uTUs/0.jpg)](https://www.youtube.com/embed/X83vac2uTUs "Extraordinary Conics: The Most Difficult Math Problem I Ever Solved")  
Extraordinary Conics: The Most Difficult Math Problem I Ever Solved
