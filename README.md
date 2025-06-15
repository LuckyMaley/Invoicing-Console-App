# Invoicing_Console_App


## Description
This system will allow employees to create invoices for products rendered to customers. It typically includes fields for details such as item descriptions, quantities, prices, taxes, discounts, and payment terms.                              
Customers will have the capability to review their invoices both before and after making payments. Each invoice will contain all necessary details, ensuring clarity and transparency in the billing process.  The system maintains a database of the customer information including contact details, billing addresses, payment preferences. This helps in accurately addressing invoices and tracking payment behaviour. Once generated, the invoices will be delivered to customers via email and electronic billing portals.  

## Tools
![Static Badge](https://img.shields.io/badge/Visual%20Studio-2022%20or%20later-green) ![Static Badge](https://img.shields.io/badge/.Net%20Framework-6.0-blue)

## Branching Strategy

A structured branching strategy must be followed to keep the codebase organized:

- **main**: Stable, production-ready code.
- **dev**: Ongoing development. Feature branches are merged here first

- **feature/**: New features.
  - Example: `feature/add-user`
- **bugfix/**: Bug fixes.
  - Example: `bugfix/fix-user-order`
- **chore/**: Maintenance tasks, documentation,or configurations.
  - Example: `chore/add-read-me`
- **Hotfix branches**: Urgent fixes to `main`.
   - Example: `hotfix/critical-bug-in-production`

### Notes:
- Use **kebab-case** (lowercase with hyphens) for branch names (e.g., `feature/dotnet-make-payment`).
- Branch names should be **descriptive** but concise.
- Avoid spaces, uppercase letters, or special characters.

## Development Workflow

1. **Create a New Branch**:
   ```bash
   git checkout -b feature/add-user
   ```

2. **Make Changes**:
   ```bash
   git add .
   git commit -m "Implement add user feature"
   ```

3. **Push Your Branch**:
   ```bash
   git push origin feature/add-user
   ```

4. **Sync with the `dev` Branch**:
   Before creating a merge request, ensure your branch is up-to-date with the latest changes from the `dev` branch:
   ```bash
   git pull origin dev
   ```
   If there are any merge conflicts, resolve them in your branch locally. Once resolved, commit the changes and push them back to your branch:
   
   ```bash
   git push origin feature/add-user
   ```

5. **Create a Merge Request**:
   - Open a pull request on GitHub targeting `dev` for code review.

## Installation
 The project relies on Visual Studio 2022 Community edition as the primary IDE for software development activities. This dependency is critical as Visual Studio provides a comprehensive suite of tools, libraries, and features necessary for building, debugging, and deploying applications using various programming languages, including C#. Furthermore, the dependency on Visual Studio 2022 Community edition offers a compelling combination of features, compatibility, accessibility, and community support, making it an ideal choice for facilitating efficient and cost-effective software development within the project.


 ### Steps

1. Go to the documents folder and then clone the project there (you can use git bash or any cmd):
```
cd Documents
```
```
git clone https://github.com/LuckyMaley/Invoicing-Console-App.git
```

2. Open the [project solution](/LLM_KC_SN_InvoicingSystem_OOD4/LLM_KC_SN_InvoicingSystem_OOD4.sln) on Visual Studio, and run the application.

## Visuals
![Screenshot (2322)](https://github.com/user-attachments/assets/46718e1a-6a90-4721-a41c-cab739e577ae)

![Screenshot (2323)](https://github.com/user-attachments/assets/a792a2e4-5902-4313-adee-a6436e92c556)

![Screenshot (2324)](https://github.com/user-attachments/assets/461fdb40-fb11-4b82-8d0f-b9bd6ca14bbe)

![Screenshot (2325)](https://github.com/user-attachments/assets/9ad1e8d5-5fc2-4e4e-ba4c-dce36ccfd398)

![Screenshot (2326)](https://github.com/user-attachments/assets/607dbcd2-e80b-47f6-8ebb-18b1951c0820)

![Screenshot (2327)](https://github.com/user-attachments/assets/f97d199d-72a0-4d9f-8529-93ebf9b3c31a)

![Screenshot (2328)](https://github.com/user-attachments/assets/519334c9-2572-4052-b236-6b38a32c3ffa)

![Screenshot (2333)](https://github.com/user-attachments/assets/40b7af72-0ae1-4024-ab69-2e654d96d5a2)

![Screenshot (2334)](https://github.com/user-attachments/assets/a55752b4-b468-4e27-a9b3-833aef9564cb)

![Screenshot (2335)](https://github.com/user-attachments/assets/323f6eb8-fdd9-4639-b535-825becd729af)

![Screenshot (2336)](https://github.com/user-attachments/assets/24ff3d79-4046-4c5e-abe9-3992c29b2f71)

![Screenshot (2337)](https://github.com/user-attachments/assets/0e029ec9-4537-4743-9d9f-65304adabd65)

![Screenshot (2338)](https://github.com/user-attachments/assets/bd3d1baf-d2c4-46c4-9d82-98248bb70c23)

