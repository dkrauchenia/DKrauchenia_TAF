Feature: Header

As a User
I want to be able to use header buttons
In order to get access to other EPAM web site pages, perform search and choose the website language

Scenario: Opening Job Listings Page through header link
    Given the user is on the main page
    And the user accepts cookies
    When the user hovers over the Careers link
    And the user clicks on the Join Our Team link
    Then the user should be redirected to the Job Listings page

Scenario: Testing Localization Dropdown
    Given the user is on the main page
    And the user accepts cookies
    When the user clicks on the language selector
    Then the user should see the following language options:
      | Language                  |
      | Global (English)          |
      | Hungary (English)         |
      | СНГ (Русский)             |
      | Česká Republika (Čeština) |
      | India (English)           |
      | Україна (Українська)      |
      | Czech Republic (English)  |
      | 日本 (日本語)               |
      | 中国 (中文)                 |
      | DACH (Deutsch)            |
      | Polska (Polski)           |
