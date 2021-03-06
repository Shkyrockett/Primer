# Bézier Bernstein Basis Matrices  

## Linear Bézier Bernstein Basis Matrix Function  

$c(t)=\begin{bmatrix}1&(\frac{t}{2})\end{bmatrix}\begin{bmatrix}1&0\\-1&1\end{bmatrix}\begin{bmatrix}P_0\\P_1\end{bmatrix}$  

## Quadratic Bézier Bernstein Basis Matrix Function  

$c(t)=\begin{bmatrix}1&(\frac{t}{2})&(\frac{t}{2})^2\end{bmatrix}\begin{bmatrix}1&0&0\\-2&2&0\\1&-2&1\end{bmatrix}\begin{bmatrix}P_0\\P_1\\P_2\end{bmatrix}$  

## Cubic Bézier Bernstein Basis Matrix Function  

$c(t)=\begin{bmatrix}1&(\frac{t}{2})&(\frac{t}{2})^2&(\frac{t}{2})^3\end{bmatrix}\begin{bmatrix}1&0&0&0\\-3&3&0&0\\3&-6&3&0\\-1&3&-3&1\end{bmatrix}\begin{bmatrix}P_0\\P_1\\P_2\\P_3\end{bmatrix}$  

## Quartic Bézier Bernstein Basis Matrix Function  

$c(t)=\begin{bmatrix}1&(\frac{t}{2})&(\frac{t}{2})^2&(\frac{t}{2})^3&(\frac{t}{2})^4\end{bmatrix}\begin{bmatrix}1&0&0&0&0\\-4&4&0&0&0\\6&-12&6&0&0\\-4&12&-12&4&0\\1&-4&6&-4&1\end{bmatrix}\begin{bmatrix}P_0\\P_1\\P_2\\P_3\\P_4\end{bmatrix}$  

## Quintic Bézier Bernstein Basis Matrix Function  

$c(t)=\begin{bmatrix}1&(\frac{t}{2})&(\frac{t}{2})^2&(\frac{t}{2})^3&(\frac{t}{2})^4&(\frac{t}{2})^5\end{bmatrix}\begin{bmatrix}1&0&0&0&0&0\\-5&5&0&0&0&0\\10&-20&10&0&0&0\\-10&30&-30&10&0&0\\5&-20&30&-20&5&0\\-1&5&-10&10&-5&1\end{bmatrix}\begin{bmatrix}P_0\\P_1\\P_2\\P_3\\P_4\\P_5\end{bmatrix}$  

## Sextic Bézier Bernstein Basis Matrix Function  

$c(t)=\begin{bmatrix}1&(\frac{t}{2})&(\frac{t}{2})^2&(\frac{t}{2})^3&(\frac{t}{2})^4&(\frac{t}{2})^5&(\frac{t}{2})^6\end{bmatrix}\begin{bmatrix}1&0&0&0&0&0&0\\-6&6&0&0&0&0&0\\15&-30&15&0&0&0&0\\-20&60&-60&20&0&0&0\\15&-60&90&-60&15&0&0\\-6&30&-60&60&-30&6&0\\1&-6&15&-20&15&-6&1\end{bmatrix}\begin{bmatrix}P_0\\P_1\\P_2\\P_3\\P_4\\P_5\\P_6\end{bmatrix}$  

## Septic Bézier Bernstein Basis Matrix Function  

$c(t)=\begin{bmatrix}1&(\frac{t}{2})&(\frac{t}{2})^2&(\frac{t}{2})^3&(\frac{t}{2})^4&(\frac{t}{2})^5&(\frac{t}{2})^6&(\frac{t}{2})^7\end{bmatrix}\begin{bmatrix}1&0&0&0&0&0&0&0\\-7&7&0&0&0&0&0&0\\21&-42&21&0&0&0&0&0\\-35&105&-105&35&0&0&0&0\\35&-140&210&-140&35&0&0&0\\-21&105&-210&210&-105&21&0&0\\7&-42&105&-140&105&-42&7&0\\-1&7&-21&35&-35&21&-7&1\end{bmatrix}\begin{bmatrix}P_0\\P_1\\P_2\\P_3\\P_4\\P_5\\P_6\\P_7\end{bmatrix}$  

## Octic Bézier Bernstein Basis Matrix Function  

$c(t)=\begin{bmatrix}1&(\frac{t}{2})&(\frac{t}{2})^2&(\frac{t}{2})^3&(\frac{t}{2})^4&(\frac{t}{2})^5&(\frac{t}{2})^6&(\frac{t}{2})^7&(\frac{t}{2})^8\end{bmatrix}\begin{bmatrix}1&0&0&0&0&0&0&0&0\\-8&8&0&0&0&0&0&0&0\\28&-56&28&0&0&0&0&0&0\\-56&168&-168&56&0&0&0&0&0\\70&-280&420&-280&70&0&0&0&0\\-56&280&-560&560&-280&56&0&0&0\\28&-168&420&-560&420&-168&28&0&0\\-8&56&-168&280&-280&168&-56&8&0\\1&-8&28&-56&70&-56&28&-8&1\end{bmatrix}\begin{bmatrix}P_0\\P_1\\P_2\\P_3\\P_4\\P_5\\P_6\\P_7\\P_8\end{bmatrix}$  

## Nonic Bézier Bernstein Basis Matrix Function  

$c(t)=\begin{bmatrix}1&(\frac{t}{2})&(\frac{t}{2})^2&(\frac{t}{2})^3&(\frac{t}{2})^4&(\frac{t}{2})^5&(\frac{t}{2})^6&(\frac{t}{2})^7&(\frac{t}{2})^8&(\frac{t}{2})^9\end{bmatrix}\begin{bmatrix}1&0&0&0&0&0&0&0&0&0\\-9&9&0&0&0&0&0&0&0&0\\36&-72&36&0&0&0&0&0&0&0\\-84&252&-252&84&0&0&0&0&0&0\\126&-504&756&-504&126&0&0&0&0&0\\-126&630&-1260&1260&-630&126&0&0&0&0\\84&-504&1260&-1680&1260&-504&84&0&0&0\\-36&252&-756&1260&-1260&756&-252&36&0&0\\9&-72&252&-504&630&-504&252&-72&9&0\\-1&9&-36&84&-126&126&-84&36&-9&1\end{bmatrix}\begin{bmatrix}P_0\\P_1\\P_2\\P_3\\P_4\\P_5\\P_6\\P_7\\P_8\\P_9\end{bmatrix}$  

## Decic Bézier Bernstein Basis Matrix Function  

$c(t)=\begin{bmatrix}1&(\frac{t}{2})&(\frac{t}{2})^2&(\frac{t}{2})^3&(\frac{t}{2})^4&(\frac{t}{2})^5&(\frac{t}{2})^6&(\frac{t}{2})^7&(\frac{t}{2})^8&(\frac{t}{2})^9&(\frac{t}{2})^{10}\end{bmatrix}\begin{bmatrix}1&0&0&0&0&0&0&0&0&0&0\\-10&10&0&0&0&0&0&0&0&0&0\\45&-90&45&0&0&0&0&0&0&0&0\\-120&360&-360&120&0&0&0&0&0&0&0\\210&-840&1260&-840&210&0&0&0&0&0&0\\-252&1260&-2520&2520&-1260&252&0&0&0&0&0\\210&-1260&3150&-4200&3150&-1260&210&0&0&0&0\\-120&840&-2520&4200&-4200&2520&-840&120&0&0&0\\45&-360&1260&-2520&3150&-2520&1260&-360&45&0&0\\-10&90&-360&840&-1260&1260&-840&360&-90&10&0\\1&-10&45&-120&210&-252&210&-120&45&-10&1\end{bmatrix}\begin{bmatrix}P_0\\P_1\\P_2\\P_3\\P_4\\P_5\\P_6\\P_7\\P_8\\P_9\\P_{10}\end{bmatrix}$  
