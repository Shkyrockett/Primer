// <copyright file="LinearRegression.cs" company="Shkyrockett" >
//     Copyright © 2020 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using Microsoft.Toolkit.HighPerformance.Memory;
using System;

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// This class create a linear regression and computes the predicted coefficients from the regression through MCO
    /// Also computes the errors and t stats
    /// </summary>
    /// <acknowledgment>
    /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/RegressionLineaire.cs
    /// </acknowledgment>
    public class LinearRegression
    {
        #region Fields
        /// <summary>
        /// The response variable
        /// </summary>
        public double[,] responseVariable;

        /// <summary>
        /// The explanatory matrix
        /// </summary>
        public double[,] explanatoryMatrix;

        /// <summary>
        /// The size data
        /// </summary>
        public int sizeData;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="LinearRegression"/> class.
        /// </summary>
        /// <param name="matrix1">The y.</param>
        /// <param name="matrix2">The x.</param>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/RegressionLineaire.cs
        /// </acknowledgment>
        public LinearRegression(Span2D<double> matrix1, Span2D<double> matrix2)
        {
            var m = matrix1.Height;
            var n = matrix1.Width;
            var p = matrix2.Height;
            var q = matrix2.Width;

            sizeData = Math.Min(m, p);
            responseVariable = Operations.Truncate(matrix1, 1, sizeData, 1, 1);
            explanatoryMatrix = Operations.Truncate(matrix2, 1, sizeData, 1, q);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add a vector of ones to estimate the constant of the model
        /// </summary>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/RegressionLineaire.cs
        /// </acknowledgment>
        public double[,] RegressionMatrix()
        {
            var vectConst = new double[sizeData, 1];

            for (var i = 0; i < sizeData; i++)
            {
                vectConst[i, 0] = 1;
            }

            return Operations.ConcatenationColumns(vectConst, explanatoryMatrix);
        }

        /// <summary>
        /// Compute the regressors coefficients from MCO
        /// beta = inv(X'*X)*X'*Y
        /// </summary>
        /// <returns>
        /// beta
        /// </returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/RegressionLineaire.cs
        /// </acknowledgment>
        public double[,] RegressorsMCO()
        {
            var R = RegressionMatrix();
            var beta = Operations.Multiply(Operations.Multiply(Operations.Inverse(Operations.Multiply(Operations.Transpose(R), R)), Operations.Transpose(R)), responseVariable);
            return beta;
        }

        /// <summary>
        /// Predictionses this instance.
        /// </summary>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/RegressionLineaire.cs
        /// </acknowledgment>
        public double[,] Predictions() => Operations.Multiply(RegressionMatrix(), RegressorsMCO());

        /// <summary>
        /// Errorses this instance.
        /// </summary>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/RegressionLineaire.cs
        /// </acknowledgment>
        public double[,] Errors() => Operations.Subtract(responseVariable, Predictions());

        /// <summary>
        /// Residuals the variance.
        /// </summary>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/RegressionLineaire.cs
        /// </acknowledgment>
        public double ResidualVariance()
        {
            var E = Errors();
            var var = Operations.Multiply(Operations.Transpose(E), E);
            var size = (double)E.GetLength(0);
            return var[0, 0] / size;
        }

        /// <summary>
        /// Variances the covariance beta.
        /// </summary>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/RegressionLineaire.cs
        /// </acknowledgment>
        public double[,] VarianceCovarianceBeta()
        {
            var R = RegressionMatrix();
            var var = ResidualVariance();
            var res = Operations.Inverse(Operations.Multiply(Operations.Transpose(R), R));

            var resRow = res.GetLength(0);
            var resCol = res.GetLength(1);

            for (var i = 0; i < resRow; i++)
            {
                for (var j = 0; j < resCol; j++)
                {
                    res[i, j] *= var;
                }
            }

            return res;
        }

        /// <summary>
        /// Tstatses this instance.
        /// </summary>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/RegressionLineaire.cs
        /// </acknowledgment>
        public double[,] Tstats()
        {
            var beta = RegressorsMCO();
            var varCovBeta = VarianceCovarianceBeta();
            var tstats = new double[beta.GetLength(0), 1];

            for (var i = 0; i < tstats.GetLength(0); i++)
            {
                tstats[i, 0] = beta[i, 0] / Math.Sqrt(varCovBeta[i, i]);
            }

            return tstats;
        }
        #endregion
    }
}
