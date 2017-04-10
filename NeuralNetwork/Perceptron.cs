﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Perceptron
    {

        protected double[] weights;
        protected double bias;
        
        private double output;

        public Perceptron(int input_nodes, Random random, bool isOutputLayer = false)
        {
            // Initialize perceptron with weights and bias to random
            double[] weights = new double[input_nodes];

            // Randomize input weights
            for (int i = 0; i < input_nodes; i++)
            {
                weights[i] = random.NextDouble() * .2 - .1;
            }

            this.weights = weights;
            if (isOutputLayer) bias = 0;
            else bias = random.NextDouble() * .2 - .1;
        }

        // Set/Get weights
        public void setWeights(double[] weights)
        {
            this.weights = weights;
        }
        public double[] getWeights()
        {
            return weights;
        }

        // Set/Get bias
        public void setBias(double bias)
        {
            this.bias = bias;
        }
        public double getBias()
        {
            return bias;
        }

        // Main perceptron elaborator
        public void execute_perceptron(double[] input)
        {
            output = sigmoid(dot_product(input, weights) + bias);
        }

        public double getOutput()
        {
            return output;
        }

        // Dot product
        private double dot_product(double[] vector1, double[] vector2)
        {
            double result = 0;
            for (int i = 0; i < vector1.Length; i++)
            {
                for (int o = 0; o < vector2.Length; o++)
                {
                    result += vector1[i] * vector2[o];
                }
            }
            return result;
        }

        // Activator functions
        private double sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
        private int binary(double x)
        {
            if (x >= 0) return 1;
            else return 0;
        }
        private double tanh(double x)
        {
            return Math.Tanh(x);
        }
    }
}
