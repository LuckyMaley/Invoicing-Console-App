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
Within a particular ecosystem, there may be a common way of installing things, such as using Yarn, NuGet, or Homebrew. However, consider the possibility that whoever is reading your README is a novice and would like more guidance. Listing specific steps helps remove ambiguity and gets people to using your project as quickly as possible. If it only runs in a specific context like a particular programming language version or operating system or has dependencies that have to be installed manually, also add a Requirements subsection.

## Visuals
Depending on what you are making, it can be a good idea to include screenshots or even a video (you'll frequently see GIFs rather than actual videos). Tools like ttygif can help, but check out Asciinema for a more sophisticated method.
