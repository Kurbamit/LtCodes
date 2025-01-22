# LtCodes

LtCodes is a .NET library for working with Lithuanian personal identification codes. This package provides functionality for validating, checking the validity of codes, generating control numbers, and extracting relevant information such as birthdate, gender, and control digits.

## Table of Contents

- [LtCodes](#ltcodes)
  - [Table of Contents](#table-of-contents)
  - [Features](#features)
  - [Installation](#installation)
  - [Example code](#example-code)
  - [Error Enums](#error-enums)

## Features

- **Validate Lithuanian ID codes**: Ensures that the given code follows the correct format.
- **Generate control numbers**: Calculates the correct control number based on a given ID.
- **Extract information**: Retrieve details like the person's birthdate, gender, and century based on the code.
- **Handle Lithuanian ID format**: Supports the standard Lithuanian ID code format.

## Installation

You can install the LtCodes package from NuGet:

bash
```
Install-Package DominykasC.Tools.LtCodes
```

Or via the .NET CLI:

```
dotnet add package DominykasC.Tools.LtCodes --version 1.0.0
```

## Example code
```
using LtCodes;

string code = "12345678901";
ValidationErrorsEnum error;
bool isValid = Validate(code, out error);

if (isValid)
{
    Console.WriteLine("Code is valid!");
}
else
{
    Console.WriteLine($"Code is invalid. Error: {error}");
}
```

## Error Enums
The `ValidationErrorsEnum` provides detailed error codes when the validation of a Lithuanian ID code fails. The following are the possible error values:
- **None (0)**: No error. The code is valid.
- **Empty (1)**: The provided code is empty or whitespace.
- **Invalid (2)**: The code does not match the required format.
- **InvalidControlNumber (3)**: The control number of the code is invalid.
- **InvalidDate (4):** The date extracted from the code is invalid.