
# Driving License Management System (DVLD)

## Overview
The Driving & Vehicle License Department (DVLD) system is designed to handle the issuance and management of driver licenses. It includes a set of services and functionalities to streamline the process of granting driving licenses and ensuring road safety.

## Main Services Provided
1. **Issuing a License for the First Time**: Application fee of $5.
2. **Re-examination Service**: Application fee of $5.
3. **Renewing Driving Licenses**: Application fee of $5.
4. **Issuing a Replacement for a Lost License**: Application fee of $5.
5. **Issuing a Replacement for a Damaged License**: Application fee of $5.
6. **Lifting the Suspension of a Driving License**: Application fee of $5.
7. **Issuing an International Driving License**: Application fee of $5.

## Application Information
- **Application Number**
- **Application Date**
- **Applicant ID**: Verified via national ID; if not present, the user must add the person to the system.
- **Request Type**: Based on the required service.
- **Application Status**: New, Cancelled, Completed.
- **Paid Application Fees**
- **For New License Issuance**:
  - License Category
  - Ensure the applicant does not already hold the same category of license.
- **Ensure no previous similar incomplete applications**.

## Applicant Information
- **National ID**
- **Full Name**
- **Date of Birth**
- **Address**
- **Phone Number**
- **Email**
- **Nationality**
- **Profile Picture**

## Service Details
1. **Issuing a License for the First Time**:
   - Applicants can apply for specific license categories, each with its own requirements, fees, and validity period.
   - Example categories include:
     - **Category 1**: Small motorcycle license (Age: 18, Fee: $15 + application fee, Validity: 5 years)
     - **Category 2**: Large motorcycle license (Age: 21, Fee: $30 + application fee, Validity: 5 years)
     - **Category 3**: Regular car license (Age: 18, Fee: $20 + application fee, Validity: 10 years)
     - **Category 4**: Commercial vehicle license (Age: 21, Fee: $200 + application fee, Validity: 10 years)
     - **Category 5**: Agricultural vehicle license (Age: 21, Fee: $50 + application fee, Validity: 10 years)
     - **Category 6**: Small and medium bus license (Age: 21, Fee: $250 + application fee, Validity: 10 years)
     - **Category 7**: Truck and heavy vehicle license (Age: 21, Fee: $300 + application fee, Validity: 10 years)

## License Class Information
- **LicenseClassID**
- **ClassName**
- **ClassDescription**
- **MinimumAllowedAge**
- **ValidityLength**
- **ClassFees**

## License Application Conditions
- **Age Requirement**: Must meet the minimum age for the license category.
- **No Existing License**: Applicant should not already hold the same license category.
- **Multiple Licenses**: Applicants can hold multiple licenses for different categories.
- **Personal Documents**: Valid identification documents required.
- **Training Completion**: Certificate of completion for vehicle training courses required.
- **Tests**: Must pass the following in order:
  1. **Vision Test**: Scheduled and results recorded; $10 fee.
  2. **Theoretical Test**: Scheduled manually, fee $20; results recorded.
  3. **Practical Driving Test**: Scheduled manually, fees based on license category; results recorded.

## Additional Services
2. **Re-examination Service**: Allows scheduling a new test after a failed attempt; $5 application fee + test fees.
3. **Renewing Driving License**: Requires vision test; $10 application fee.
4. **Issuing Replacement for Lost/Damaged License**: $20 application fee.
5. **Lifting License Suspension**: Payment of fine and recording the suspension lift date.
6. **Issuing International License**: For holders of category 3 licenses; $20 fee.

## System Administration
- **User Management**: Add, view, edit, delete, freeze user accounts, and assign permissions.
- **Person Management**: Search, view, add, edit, delete persons; ensure no duplicate national IDs.
- **Application Management**: Search, view, edit applications; filter by status.
- **Test Management**: Edit test prices.
- **License Category Management**: Edit age, validity, and fees.
- **License Suspension Management**: Record license suspension details and fines.

## Audit and Logging
- All system activities must record the user who performed the action and the date of the action.
