# Payroll Extract Generator

## Table of Contents

- [Overview](#overview)
- [Business Details](#business-details)
  - [Payroll Extract Details](#payroll-extract-details)
  - [Entry Details](#entry-details)
  - [Calculation Methodologies](#calculation-methodologies)
  - [Example Calculation](#example-calculation)
- [Technical Details](#technical-details)
  - [Architecture](#architecture)
  - [Technologies Used](#technologies-used)
  - [Development Environment Setup](#development-environment-setup)
  - [Project Structure](#project-structure)
  - [Running the Project](#running-the-project)
  - [Routes and Functionality](#routes-and-functionality)
- [Technical Debt and Future Improvements](#technical-debt-and-future-improvements)
- [Contribution](#contribution)
- [Credits](#credits)
  - [Documentation](#documentation)
  - [Development](#development)

## Overview

The Payroll Extract Generator is a web application designed to simplify the process of generating payroll extracts for employees. It provides a user-friendly interface for managing employee data, calculating gross salaries, applying deductions, and generating detailed payroll reports.

## Business Details

### Payroll Extract Details

The payroll extract should be able to display the following information:

- **Reference Month:** The month to which the payroll extract refers.
- **List of Entries:** A list of entries detailing the income and deductions for the employee.
- **Gross Salary:** The total salary before any deductions.
- **Total Deductions:** The total amount deducted from the salary (negative value).
- **Net Salary:** The remaining salary after deductions.

### Entry Details

An entry in the payroll extract consists of the following:

- **Type:** Whether it is a deduction or remuneration.
- **Value:** The monetary value of the entry.
- **Description:** A description of the entry, such as "Transportation Voucher," "INSS," "IRRF," etc.

### Calculation Methodologies

#### Gross Salary

The gross salary is calculated by summing all the income entries (remunerations) for the employee.

#### Total Deductions

The total deductions are calculated by summing all the deduction entries for the employee. This includes entries such as INSS, IRRF, health plan deductions, etc.

#### Net Salary

The net salary is calculated by subtracting the total deductions from the gross salary.

### Example Calculation

Suppose an employee's gross salary is $5000, and their deductions total $1000. The net salary would be $4000 ($5000 - $1000).

### Salary Deductions Calculation

1. **INSS (on gross salary):**

   - **Contribution Salary | INSS Rate**
   - Up to 1,045.00 | 7.50%
   - 1,045.01 to 2,089.60 | 9%
   - 2,089.61 to 3,134.40 | 12%
   - 3,134.41 to 6,101.06 | 14%

2. **Income Tax Withholding (on gross salary):**

   - **Base Calculation (R$) | Tax Rate (%) | Deduction Amount (R$)**
   - Up to 1,903.98 | - | -
   - 1,903.90 to 2,826.65 | 7.5 | 142.8
   - 2,826.66 to 3,751.05 | 15 | 354.8
   - 3,751.06 to 4,664.68 | 22.5 | 636.13
   - Above 4,664.68 | 27.5 | 869.36

3. **Health Plan (R$ 10 fixed on gross salary, if the employee opts for the plan)**

4. **Dental Plan (R$ 5 fixed on gross salary, if the employee opts for the plan)**

5. **Transportation Voucher (6% on gross salary, if the employee opts for the voucher)**

   - (No deduction if the employee earns less than R$ 1500)

6. **FGTS (8% on gross salary)**

## Technical Details

### Architecture

The project follows a modular architecture inspired by Domain-Driven Design (DDD) and Clean Architecture principles. It is structured into several layers:

- **Presentation Layer (Api):** Exposes RESTful endpoints for interacting with the application.
- **Application Layer:** Contains the business logic, including Use Cases and Services.
- **Domain Layer:** Defines the core business entities and value objects.
- **Infrastructure Layer:** Implements data access, external services, and other infrastructure-related functionality.

### Technologies Used

- **ASP.NET Core:** Framework for building web applications.
- **Entity Framework Core:** Object-relational mapping (ORM) framework for database interactions.
- **Docker:** Containerization platform for easy deployment.
- **SQL Server:** Database management system for storing employee and payroll data.

### Development Environment Setup

To set up the development environment, follow these steps:

1. Install the [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).
2. Install [Docker](https://www.docker.com/products/docker-desktop).

### Project Structure

The project is structured as follows:

- `src/Api`: Web API project containing controllers and endpoints.
- `src/Application`: Application layer with Use Cases and Services.
- `src/Domain`: Domain layer with Entities and Value Objects.
- `src/Infrastructure`: Infrastructure layer with Data Access and External Services implementations.
- `tests`: Unit tests for the application.

### Running the Project

To run the project locally, follow these steps:

1. Clone the repository: `git clone https://github.com/username/payroll-extract-generator.git`.
2. Navigate to the project directory: `cd payroll-extract-generator`.
3. Run the Docker Compose command: `docker-compose up`.

### Routes and Functionality

- **GET /api/employees/{id}:** Retrieve an employee by ID.
- **POST /api/employees:** Create a new employee.
- **GET /api/payroll/extracts/{id}:** Retrieve a payroll extract by ID.

### Technical Debt and Future Improvements

- **Token Validation:** Implement token validation to ensure the authenticity and proper authorization of requests.
- **Fail Fast:** Refactor the code to follow the fail-fast principle, identifying and handling errors as early as possible in the execution flow.
- **Employee Change History Base:** Create a database or mechanism to record and query the change history of employees, keeping a record of all significant changes.
- **Integrated Tests:** Implement integrated tests to verify the interaction between different components of the system, ensuring they function correctly together.
- **Increased Unit Test Coverage:** Add more unit tests to cover a greater portion of the code, ensuring that functionalities are thoroughly tested.
- **Load Testing:** Implement load tests to assess the performance of the system under different load conditions, identifying potential bottlenecks and optimizations.
- **Functional Testing:** Add functional tests to verify that the system meets functional requirements, ensuring that functionalities behave as expected.

### Contribution

1. Fork the repository.
2. Make your changes.
3. Open a pull request.

### Credits

#### Documentation

This documentation was created with the assistance of AI (Artificial Intelligence) to improve its readability and accuracy.

#### Development

This project was developed by a single contributor:

[![LinkedIn](https://img.shields.io/badge/LinkedIn-Contact%20Me-blue?style=flat-square&logo=linkedin)](https://www.linkedin.com/in/andrade-italo/)
[![Gmail](https://img.shields.io/badge/Gmail-Contact%20Me-red?style=flat-square&logo=gmail)](mailto:italoandrade13@gmail.com)

If you have any suggestions or feedback, feel free to get in touch.
