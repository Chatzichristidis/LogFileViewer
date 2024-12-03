# Project Background  
The LogViewer project was created during my 2-week internship to develop a program for analyzing and compressing log files. The focus was on processing time analysis, identifying job runs, and detecting errors. The core functionality transforms raw log data into a structured table format, enabling grouping, filtering, and time calculations. Key features were designed to include graphical representations of task phases, actions, and job progress. The program allows users to load, filter, and analyze log data, offering valuable insights into the scanning process from start to finish.

While completing the full project required more time than the internship allowed, I made initial progress during the two weeks. My efforts focused on setting up the user interface, enabling file loading, and establishing basic data parsing. Despite the short timeline, I successfully created a foundation where the program could begin processing log files and generating basic visualizations.

In the long term, the LogViewer aims to provide detailed time analyses, error detection, and powerful visualization tools, helping users interpret large log datasets in a clear and interactive way.

# Changelog
### **26.11**  
- Implemented a **Dropdown List** as part of the interface to enhance user experience.  
- Continued developing the program using a **WebApp-based approach** (HTML, JavaScript, C#).  
- Completed the first version of the interface, which included the Dropdown List and other key elements.  

---

### **27.11**  
- **Cache System Development:**  
  - Created a **Dropdown List Function** to allow users to interact with the cache (e.g., selecting cache size or managing items).  
  - Started filling out the **table headers** for organizing cache-related data (e.g., cache size, stored items, access times).  
- **Rebuilt the Program:**  
  - Transitioned to a **WinFileApps-based approach** from the earlier WebApp version.  
  - Designed a new **User Interface (UI)** with the following features:  
    - Timer  
    - Progress Bar  
    - Dropdown List  
    - Integrated **File Explorer** for improved user interaction.  

---

### **28.11**  
- Advanced **Cache System Development:**  
  - Recreated the Dropdown List Function for interacting with the system.  
  - Added headers to the table to categorize and display key cache data.  
- New Features:  
  - Implemented a **Drag and Drop** function.  
  - Added **data storage functionality** for the most recently used items:  
    - First using a `.txt` file.  
    - Later refined to use a `.json` file.  

---

### **29.11**  
- Enhanced **Data Persistence:**  
  - Migrated the storage system to use the **Windows Registry** for reliable data persistence.  
- Began working with **StreamReader:**  
  - Gained foundational knowledge of loading log files into a **DataTable**.  
  - Integrated StreamReader to display and filter **log files** in a table, focusing on a specific version.  

---

### **02.12**  
- Created **two new classes** to improve code readability and maintainability.  
- Extended program capabilities to process **log files** with specific formats:  
  - Implemented logic using StreamReader to read these files and display data in the table.  
- Adjusted implementation to support additional log file formats with structural differences.  
