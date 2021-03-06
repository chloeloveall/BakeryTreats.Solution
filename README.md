![Proof splash page screenshot](Bakery/wwwroot/img/proof-screenshot.png)

# _Proof: By Pierre_

#### _An MVC application that allows a fictional bakery owner to maintain a database with their baked goods and flavors when logged in to the site._

#### By _**Chloe Loveall**_
<br>

![license](https://img.shields.io/github/license/chloeloveall/BakeryTreats.Solution?color=blue&style=flat-square) &nbsp; ![top project language](https://img.shields.io/github/languages/top/chloeloveall/BakeryTreats.Solution?style=flat-square) &nbsp; ![last github commit](https://img.shields.io/github/last-commit/chloeloveall/BakeryTreats.Solution?style=flat-square) &nbsp; ![github pull requests](https://img.shields.io/github/issues-pr/chloeloveall/BakeryTreats.Solution?style=flat-square) &nbsp; ![open issues](https://img.shields.io/github/issues-raw/chloeloveall/BakeryTreats.Solution?style=flat-square) &nbsp; ![github contributors](https://img.shields.io/github/contributors/chloeloveall/BakeryTreats.Solution?color=brightgreen&style=flat-square)

## Table of Contents

1. [Table of Contents](#table-of-contents)
2. [Description](#description)
3. [Preview](#preview)
4. [Technologies Used](#technologies-used)
5. [Setup and Installation Requirements](#setup-and-installation-requirements)
    * [Prior to Installation](#prior-to-installation)
      * [Git Installation](#confirm-you-have-git-installed)
      * [.NET Installation](#confirm-you-have-.net-installed)
    * [Installation](#installation)
    * [Database Setup](#database-setup)
      * [MySQL Password Protection](#mysql-password-protection)
      * [Entity Framework Core Database Setup](#entity-framework-core-database-setup)
    * [Launching the Program](#launching-the-program)
6. [User Stories](#user-stories)
7. [Specifications](#specifications)
8. [Known Bugs](#known-bugs)
9. [Issues](#issues)
10. [Roadmap](#roadmap)
11. [Design](#design)
12. [Contributing](#contributing)
13. [License](#license)
14. [Acknowledgements](#acknowledgements)
15. [Contact Information](#contact-information)

## Description

An [Epicodus](https://www.epicodus.com/) project to create an MVC web application to help a fictional bakery owner manage the company's treats and treat flavors. The owner can create, view, edit and delete available treats and treat flavors. The home index page display lists of all current flavors and current treats.

## Preview

Live preview - not yet deployed  

## Technologies Used

* ASP.NET 5.0.1
* C#
* Entity Framework 5.0.0
* MySQL 8.0.15
* MySQL Workbench 8.0.15
* Razor

## Setup and Installation Requirements

### Prior to Installation

#### Confirm you have Git installed
  * Installing Git on Macs:
    * Install the package manager [Homebrew](https://brew.sh/) by copying and pasting the following in the terminal: ```$ /usr/bin/ruby -e "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install)"```
    * Copy and paste once of the following lines in the terminal so that Homebrew packages are run before the system versions of the same packages:
      * For bash users: ```$ echo 'export PATH=/usr/local/bin:$PATH' >> ~/.bash_profile```
      * For zsh users: ```$ echo 'export PATH=/usr/local/bin:$PATH' >> ~/.zshrc```
    * Last, install Git with the following terminal command: ```$ brew install git```

  * Installing Git on Windows:
    * Open Command Prompt, the Windows terminal program. You can access it by typing ```Cmd``` in the search bar in the bottom left corner.
    * **NOTE** There are many options available, but we recommend using a free program called [Git Bash](https://gitforwindows.org/)
    * Navigate to [Git Bash](https://gitforwindows.org/) and click on the Download button. This will take you to a page with the latest version of Git Bash. Determine whether you have 32-bit or 64-bit Windows by following these instructions. Then download the corresponding exe file from the Git for Windows site. (If you have a package manager already installed, you can also choose to download the tar.bz2 version.)
    * Click on the downloaded file and then follow the instructions in the Setup menu until you reach the Install button and install the package.
    
#### Confirm you have .NET installed 
Installing .NET will provide provide access to the C# language
  * [.NET for macOS](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.100-macos-x64-installer)
  * [.NET for Windows](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.102-windows-x64-installer)
* Additionally, you may want to install a REPL to allow you to practice, test, and experiment with C#. Below are instructions for the ```dotnet script``` REPL:
  * Install ```dotnet script``` by running the following terminal command: ```$ dotnet tool install -g dotnet-script```
  * **NOTE:** If you just installed .NET 5, restart the terminal. (Otherwise, you will not be able to run the following command.) 
    * Enter ```$ dotnet script``` in your terminal and a prompt will open: ```>```
    * To exit the REPL press: Ctrl +C

### Installation
* Clone the repository with the following git terminal command: ```$ git clone https://github.com/chloeloveall/BakeryTreats.Solution.git```
* Open the project directory in your terminal
* Navigate to the ```Bakery``` directory (the production directory)
    * To create an ```obj``` directory and install dependencies, run the terminal command: ```$ dotnet restore```
    * **NOTE**: Do not touch the code in the ```obj``` directory.

### Database Setup 

#### MySQL Password Protection
* Create a the following file: ```appsettings.json```
* Add the following code: 

  ![Setup of appsettings.json Screenshot](Bakery/wwwroot/img/appsettings-screenshot.png)
* **NOTE**: [YOUR_DATABASE] must match the database name you chose to import above
* **NOTE**: [YOUR_PASSWORD] must match your local MySQL server password
* **NOTE**: The ```appsettings.json``` file is included in the ```.gitignore``` file 
  * You can read more about best practices for storing private information with ASP.NET Core [here](https://www.humankode.com/asp-net-core/asp-net-core-configuration-best-practices-for-keeping-secrets-out-of-source-control)

#### Entity Framework Core Database Import
* Confirm you have [MySQL](https://dev.mysql.com/downloads/file/?id=484914) installed
* Confirm you have [MySQL Workbench](https://dev.mysql.com/downloads/file/?id=484391) installed
* From the production directory (```BakeryTreats.Solution/Bakery```), run the following terminal command: ```dotnet ef migrations add Initial```
* Then, also from the production directory, run this command: ```dotnet ef database update```
* Open MySQL Workbench and verify that there is a new database with the database name you specified in the ```appsettings.json``` file

#### MySQL Workbench Database Import
* **NOTE**: This is an alternate option to import the database. This step is not necessary if you complete the Entity Database Import steps above 
* Open ```MySQL Workbench``` and select ```Local Instance 3306```
* In the ```Administration``` tab, select ```Data Import/Restore``` 

![Data Import/Restore Screenshot](Bakery/wwwroot/img/data-import-screenshot.png)
* Select ```Import from Self-Contained File```
* Select the file ```chloe_loveall.sql``` from the ```BakeryTreats.Solution``` root directory
* Select ```New``` from the ```Default Schema to be Imported To``` section 

![Default Schema Screenshot](Bakery/wwwroot/img/default-schema-screenshot.png)
* Choose a name for the database and select ```Ok```
* Select ```Start Import```

### Launching the program
* You are now ready to run the program! To launch the program, navigate to the production directory (```BakeryTreats.Solution/Bakery```) and run the following terminal command: ```dotnet run```
  * **NOTE**: You can alternately use ```dotnet watch run``` if you would like to make and view changes without needing to relaunch ```dotnet run```
* In the browser of your choice, navigate to: ```http://localhost:5000/``` 
  
## User Stories

* As the bakery owner, I need to be able to see a list of all treats, and I need to be able to see a list of all flavors.
* As the bakery owner, I need to be able to select a treat, see its details, and see a list of all available flavors for that treat. I also need to be able to select a flavor, see its details, and see a list of all treats available in that flavor.
* As the bakery owner, I need to add new treats to our system when they are added to the menu. I also need to add new flavors to our system when they are in season/added to the menu.
* As the bakery owner, I should be able to add new treats even if no flavors have been added. I should also be able to add new flavors even if no treats have been added.
* As the bakery owner, I need to be able to add or remove flavors that a specific treat is available in. I also need to be able to modify this relationship from the other side, and add or remove treats from a specific flavor.
* I should be able to navigate to a splash page that lists all treats and flavors. Users should be able to click on an individual treat or flavor to see all the treats/flavors that belong to it.

## Specifications

| Behavior                                                         | Input                      | Output                     |
| ---------------------------------------------------------------- | :------------------------- | :------------------------- |

## Known Bugs

* None at this time 

## Issues 

* Report issues [here](https://github.com/chloeloveall/BakeryTreats.Solution/issues) and select the ```New issue``` button
for support and

## Roadmap

* Complete UI
* Add additional model properties
* Have separate roles for admins and logged-in users. Only admins should be able to add, update and delete.
* Add an order form that only logged-in users can access. A logged-in user should be able to create, read, update and delete their own order.

### Design

* Animated logo designed with [Canva](https://www.canva.com/)

   ![Proof logo gif](Bakery/wwwroot/img/proof-logo.gif)

## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are greatly appreciated.

1. Fork the project on GirHub
    * Follow [Installation and Setup Requirements](#setup-and-installation-requirements) above
2. Create your Feature Branch: ```$ git checkout -b YourFeatureBranchName```
3. Commit your Changes ```$ git commit -m 'Add some Amazing Feature'```
4. Push to your feature branch on Github ```$ git push origin YourFeatureBranchName```
5. Open a Pull Request

## License

[MIT](LICENSE.md)

## Acknowledgements

* [Canva](https://www.canva.com/)
* [Choose an open source license](https://choosealicense.com/)
* [Codepen.io/ClaireLarsen](https://codepen.io/ClaireLarsen/pen/XmVyVX)
* [Coolors](https://coolors.co/)
* [Microsoft C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [Pexels: Royalty Free Images](https://www.pexels.com/royalty-free-images/)
* [Shields](https://shields.io/)
* [Unplash: Photos for Everyone](https://unsplash.com/)
* [Cupcake Ipsum](http://www.cupcakeipsum.com/)

## Contact Information

_Chloe Loveall <chloeloveall@protonmail.com>_

![github followers](https://img.shields.io/github/followers/chloeloveall?style=social) &nbsp; ![github forks](https://img.shields.io/github/forks/chloeloveall/BakeryTreats.Solution?label=Forks&style=social) &nbsp; ![github stars](https://img.shields.io/github/stars/chloeloveall/BakeryTreats.Solution?style=social)

[Back to Top](#table-of-contents)