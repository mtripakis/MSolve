﻿using ISAAR.MSolve.Matrices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSAR.MSolve.IGAPreProcessor
{
    public class IGAModel
    {
        private int totalDofs;
        private int numberOfDimensions;

        private int numberOfCPKsi;
        private int numberOfCPHeta;
        private int numberOfCPZeta;
        //private int thickness;

        private int degreeKsi;
        private int degreeHeta;
        private int degreeZeta;
        private Vector<double> knotValueVectorKsi;
        private Vector<double> knotValueVectorHeta;
        private Vector<double> knotValueVectorZeta;
        private readonly IList<ControlPoint> controlPoints = new List<ControlPoint>();
        private readonly IList<Knot> knots = new List<Knot>();
        private readonly IList<Element> elements = new List<Element>();
        private readonly IList<IGALoad> loads = new List<IGALoad>();

        #region Properties
        public int TotalDOFs
        {
            get { return this.totalDofs; }
            set { numberOfDimensions=value; }
        }

        public int NumberOfDimensions
        {
            get { return this.numberOfDimensions; }
            set { numberOfDimensions = value; }
        }

        public int DegreeKsi
        {
            get { return this.degreeKsi; }
            set { degreeKsi = value; }
        }

        public int DegreeHeta
        {
            get { return this.degreeHeta; }
            set { degreeHeta = value; }
        }

        public int DegreeZeta
        {
            get { return this.degreeZeta; }
            set { degreeZeta = value; }
        }

        public Vector<double> KnotValueVectorKsi
        {
            get { return this.knotValueVectorKsi; }
            set { knotValueVectorKsi = value; }
        }

        public Vector<double> KnotValueVectorHeta
        {
            get { return this.knotValueVectorHeta; }
            set { knotValueVectorHeta = value; }
        }

        public Vector<double> KnotValueVectorZeta
        {
            get { return this.knotValueVectorZeta; }
            set { knotValueVectorZeta = value; }
        }

        public int NumberOfCPKsi
        {
            get { return numberOfCPKsi; }
            set { numberOfCPKsi = value; }
        }

        public int NumberOfCPHeta
        {
            get { return numberOfCPHeta; }
            set { numberOfCPHeta = value; }
        }

        public int NumberOfCPZeta
        {
            get { return numberOfCPZeta; }
            set { numberOfCPZeta = value; }
        }

        public IList<ControlPoint> ControlPoints
        {
            get { return controlPoints; }
        }

        public IList<Knot> Knots
        {
            get { return knots; }
        }

        public IList<Element> Elements
        {
            get { return elements; }
        }

        public IList<IGALoad> Loads
        {
            get { return loads; }
        }

        #endregion

        #region Data Creation Routines
        public void CreateDataStructures()
        {

        }
        #endregion

        public void Clear()
        {
            this.controlPoints.Clear();
            this.knots.Clear();
            this.elements.Clear();

        }

        public void CreateModelData(Matrix2D<double> cpCoordinates)
        {
            if (this.numberOfDimensions == 2)
            {
                CreateModelData2D(cpCoordinates);
            }else
            {
                CreateModelData3D(cpCoordinates);
            }
        }

        private void CreateModelData2D(Matrix2D<double> cpCoordinates)
        {

        }

        private void CreateModelData3D(Matrix2D<double> cpCoordinates)
        {

        }

        private Vector<double> FindParametricCoordinates(int degree, Vector<double> knotValueVector)
        {
            if (degree <= 0)
            {
                throw new NotSupportedException("Negative Degree.");
            } else if (knotValueVector == null)
            {
                throw new ArgumentNullException("Knot Value Vector is null.");
            }

            int numberOfControlPoints = knotValueVector.Length - degree - 1;

            Vector<double> parametricCoordinates = new Vector<double>(numberOfControlPoints);

            for (int i = 0; i < numberOfControlPoints; i++)
            {
                int leftID = (int)Math.Floor(i + (degree + 1) / 2.0);
                int rightID = (int)Math.Ceiling(i + (degree + 1) / 2.0);

                parametricCoordinates[i] = (knotValueVector[leftID] + knotValueVector[rightID]) / 2.0;
            }

            return parametricCoordinates;

        }
    }
}
