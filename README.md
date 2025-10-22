
# SouthAfricaMuni - Community Service Management System

## Overview

**SouthAfricaMuni** is a Windows Forms application designed to help manage community service-related activities, including the reporting of issues, viewing service request statuses, and managing events and announcements. The application allows users to log issues, which are then categorized and prioritized, providing an organized and efficient way for administrators to track, manage, and resolve service requests within a municipality or community.

This project is intended to simplify communication between community members and the local service departments. It incorporates features like issue reporting, event management, and a search functionality to improve responsiveness and service delivery.

---

## Features

- **Issue Reporting:** Allows community members to report issues such as potholes, broken street lights, and other infrastructure problems.
- **Issue Prioritization:** Issues are categorized by date and can be prioritized to address the most urgent cases first.
- **Event Management:** Organize and display events and announcements related to the community.
- **Search Functionality:** Users can search for issues by ID, location, or category.
- **Interactive UI:** The application is built with a clean and intuitive user interface to ensure a seamless experience for all users.
- **Real-Time Updates:** The list of reported issues and events is dynamically updated based on user input and new data submissions.
- **Max Heap Implementation:** Utilizes a Max Heap to store and prioritize issues, ensuring that the most urgent problems are displayed first.
- **Category-Based Organization:** Issues are organized in a tree view by category for easy access and navigation.

---

## Installation

To get started with **SouthAfricaMuni**, follow these steps:

### Prerequisites

- **Windows OS** (Windows 7 or higher recommended)
- **Microsoft Visual Studio** (2019 or later)
- **.NET Framework** (Version 4.7.2 or higher)

### Clone the Repository

1. Clone this repository to your local machine using Git:
    ```bash
    git clone https://github.com/VCDN-2024/prog7312-part-1-Kalkidan-Negaro/tree/master
    ```

### Setting Up the Project

1. Open **Visual Studio**.
2. Select **File** > **Open** > **Project/Solution**.
3. Navigate to the folder where you cloned the repository and open the `SouthAfricaMuni.sln` solution file.

### Running the Application

1. In **Visual Studio**, ensure that the correct build configuration (Debug/Release) is selected.
2. Press **F5** or click **Start** to run the application.

---

## Usage

Once the application is running, you can interact with it through several sections:

### Reporting an Issue

1. Navigate to the **Issue Reporting** section.
2. Enter the required information:
   - **Location**: The specific location where the issue was encountered.
   - **Category**: Choose the category of the issue (e.g., Pothole, Broken Street Light).
   - **Description**: Provide a brief description of the issue.
3. Press the **Submit Issue** button to add the issue to the list.
4. An **Issue ID** which is a unique identifier for the issue will be self generated
5. The issue will be added to the Max Heap and displayed in the **DataGridView** in descending order of priority.

### Viewing Issues

- The **DataGridView** will display a list of reported issues, including:
  - **Issue ID**
  - **Location**
  - **Category**
  - **Reported Date**
- Clicking on the **View** button in any row will display detailed information about the selected issue.

### Navigating the Issue Categories

- The **TreeView** on the left shows all issues organized by category.
- Expand each category to view specific issues under it.

### Searching for Issues

- Use the **Search Box** at the top of the form to filter issues by:
  - Issue ID
  - Location
  - Category
- The list and tree view will dynamically update to reflect the search results.

### Event and Announcement Management

- In the **Events and Announcements** section, users can view upcoming events or announcements related to the community.
- Add new events by navigating to the **Add Event** form.

---

## Architecture

### 1. **Data Management:**

- The `IssueReport` class is used to store the data related to each reported issue, including:
  - **Issue ID**
  - **Location**
  - **Category**
  - **Description**
  - **Reported Date**

- The **MaxHeap** class is used to prioritize the issues based on severity. The issues are inserted into the heap, and they are sorted such that the most urgent issues are retrieved first.

### 2. **UI Design:**

- **Windows Forms** is used for the user interface.
- The main form contains:
  - A **DataGridView** for displaying issues.
  - A **TreeView** for displaying issues organized by category.
  - A **Search Box** for filtering issues.
  - **Buttons** for submitting new issues and navigating back to the main menu.

### 3. **Event-Driven Programming:**

- The application uses event handlers to interact with the UI elements. For example:
  - Clicking the **Submit Issue** button triggers the addition of a new issue.
  - Selecting an issue from the **DataGridView** triggers the display of issue details.

---

## Technical Details

### Classes:

- **IssueReport**: This class holds all the necessary data for an issue report, such as the issue ID, location, category, description, and the reported date.
  
- **MaxHeap**: A data structure that helps store issues in a way that the most urgent issues (based on priority) are retrieved first. The `Insert` method adds an issue to the heap, and the `RemoveMax` method extracts the highest-priority issue.

### Dependencies:

- **System.Windows.Forms**: Used to create the graphical user interface (GUI).
- **System.Linq**: Provides LINQ methods for grouping and filtering issues.

---

## Contributing

If you would like to contribute to the development of **SouthAfricaMuni**, follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes and commit them (`git commit -am 'Add feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Open a pull request.

---

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## Acknowledgments

- **Stack Overflow** for the invaluable community support.
- **Microsoft** for creating Visual Studio and .NET Framework.
- **GitHub** for hosting this repository.

---

## Contact

For questions, feedback, or inquiries, feel free to reach out at:

- **Email**: kalkidan2017negaro@Gmail.com
- **GitHub**: https://github.com/Kalkidan-Negaro

---
