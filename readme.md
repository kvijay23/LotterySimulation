# LotterySimulation

LotterySimulation is a .NET 8.0 application that simulates a lottery system. The project is structured into multiple components, including core services, domain logic, infrastructure, and unit tests.

## Project Structure

- **LotterySimulation.App**: The main application project.
- **LotterySimulation.Core**: Contains core services and interfaces.
- **LotterySimulation.Domain**: Contains domain logic and entities.
- **LotterySimulation.Infrastructure**: Contains infrastructure-related code.
- **LotterySimulation.UnitTests**: Contains unit tests for the application.

## Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022

## Getting Started

### Clone the Repository

git clone https://github.com/your-repo/LotterySimulation.git cd LotterySimulation


### Build the Solution

Open the solution in Visual Studio 2022 and build the entire solution to restore the necessary packages and compile the projects.

### Running the Application

1. Set `LotterySimulation.App` as the startup project.
2. Run the application using Visual Studio or the .NET CLI:


### Running Unit Tests

To run the unit tests, you can use the Test Explorer in Visual Studio or the .NET CLI:


## Project Details

### Core Services

The core services are located in the `LotterySimulation.Core` project. The main service is `PrizeCalculator`, which implements the `IPrizeCalculator` interface.

#### PrizeCalculator

The `PrizeCalculator` class calculates the distribution of prizes based on the total revenue.





