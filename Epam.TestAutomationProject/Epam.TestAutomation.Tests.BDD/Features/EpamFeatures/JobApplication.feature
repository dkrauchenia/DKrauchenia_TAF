Feature: JobApplication

As a user
I want to be able to observe pages related to career in EPAM
In order to be able to apply for a job in the company

Scenario: Verify List of Available Regions
   Given the user navigates to the main page
   And the user accepts all cookies
   When the user clicks on the Careers link in the header
   And the user clicks on the Find Your Dream Job link
   And the user scrolls to the Our Locations section
   Then the user should see the following list of available countries:
      | Country  |
      | AMERICAS |
      | EMEA     |
      | APAC     |

Scenario: Verify navigation to Job Application Page
   Given the user navigates to the main page
   And the user accepts all cookies
   When the user clicks on the Careers link in the header
   And the user clicks on the Find Your Dream Job link
   And the user scrolls to the bottom of the page
   And the user clicks on the Register Your Interest Button
   Then the user should be redirected to the Job Application Page

