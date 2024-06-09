using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.IO;

namespace YourNamespace.Models
{
    public class MLModel_Sport
    {
        public class ModelInput
        {
            [ColumnName("ImageSource"), LoadColumn(0)]
            public byte[] ImageSource { get; set; }
        }

        public class ModelOutput
        {
            [ColumnName("PredictedLabel")]
            public string PredictedLabel { get; set; }

            [ColumnName("Score")]
            public float[] Score { get; set; }
        }

        private static Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictionEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(CreatePredictionEngine);

        public static ModelOutput Predict(ModelInput input)
        {
            var predictionEngine = PredictionEngine.Value;
            return predictionEngine.Predict(input);
        }

        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictionEngine()
        {
            var mlContext = new MLContext();
            // Ensure the model path is correct and points to the new model file
            string modelPath = @"C:\path\to\your\new\model.zip";
            ITransformer mlModel = mlContext.Model.Load(modelPath, out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
            return predEngine;
        }
    }
}
