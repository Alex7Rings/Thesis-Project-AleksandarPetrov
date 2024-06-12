# Тhesis_Project_AleksandarPetrov
# Image Classification with ML.NET and ASP.NET MVC

## Table of Contents

- [Objective](#objective)
- [Data](#data)
- [Development](#development)
- [Evaluation and Testing](#evaluation-and-testing)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Screenshots](#screenshots)
- [License](#license)

## Objective

The objective of this project is to demonstrate the capabilities of ML.NET for image classification tasks within an ASP.NET MVC framework. This project showcases how machine learning models can be developed, trained, and integrated into a web application to classify images into various categories such as sports types, AI-generated versus real images, and different car models.

## Data

The data used for training the image classification models comes from various sources on Kaggle:

1. **Sports Image Classification**:
   - [Sports Image Classification](https://www.kaggle.com/datasets/sheikhzaib/sports-image-image-classification)

2. **AI-Generated vs. Real Images**:
   - [AI-Generated Images vs. Real Images](https://www.kaggle.com/datasets/cashbowman/ai-generated-images-vs-real-images)

3. **Car Model Classification**:
   - [Car Models A](https://www.kaggle.com/datasets/benlaw/car-models-a)
   - [Car Models B](https://www.kaggle.com/datasets/benlaw/car-models-b)
   - [Over 20 Car Brands Dataset](https://www.kaggle.com/datasets/alirezaatashnejad/over-20-car-brands-dataset)

## Development

### Data Preparation

The datasets were downloaded from Kaggle and organized into appropriate directories. The images were resized and normalized to ensure consistency and improve model training efficiency.

### Model Building with ML.NET

The models were built using ML.NET Model Builder, a tool integrated into Visual Studio. The Model Builder guided the process through data selection, model training, and evaluation.

### Integration into ASP.NET MVC

The trained models were integrated into an ASP.NET MVC application. Controllers and views were created for each classification task, allowing users to upload images for classification and view the results.

- **Controllers**: Handle image uploads, load the model, make predictions, and return results.
- **Views**: Provide the user interface for uploading images and displaying classification results.
- **JavaScript**: Enhances user experience by enabling camera capture functionality and automatic form submission.

## Evaluation and Testing

### Model Evaluation

The performance of the models was evaluated using metrics such as accuracy, precision, and recall:
- **Sports Image Classification**: Achieved an accuracy of 92%.
- **AI-Generated vs. Real Images**: Achieved an accuracy of 85%.
- **Car Model Classification**: Achieved an accuracy of 90%.

### Testing

- **Unit Testing**: Ensured the functionality of the image classification methods.
- **Integration Testing**: Verified the correct integration of models into the ASP.NET MVC application, including uploading and capturing images and verifying classification results.

## Getting Started

### Prerequisites

- Visual Studio 2019 or later
- .NET 5.0 or later
- ML.NET Model Builder


## Usage

1. **Run the Application**: Start the application from Visual Studio.
2. **Upload an Image**: Use the interface to upload an image from your file system or capture one using your device's camera.
3. **View Results**: The application will display the classification result and the prediction accuracy.


---

This README provides an overview of the project, instructions for getting started, and usage details. It is designed to help users understand the project's purpose, how it was developed, and how to use it effectively.
