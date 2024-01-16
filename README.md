# se4458_final
For authentication you can try: <br/>
"username" = admin "password" = 12345 <br/>
# Design:
   **Purpose and Scope of the project:** <br/>
    Purpose of the project is creating an pharmacy system using web services.<br/>
   **The project offers several functionalities:**<br/>
      1- Get, update , delete for prescription.<br/>
      2- Query Medicines with name.(Supports pagination)<br/>
      3- Scheduled payment service.<br/>
      4- Login for authentication.<br/>
 **Authentication:**<br/>
    For authentication, I used JWT tokens.<br/>
    When user login, token will be given to user.<br/>
  **Pagination:**<br/>
    Users can query medicines with pagination.<br/>
  **Caching:**  <br/>
    Query medicines cache data for every 30 sec.<br/>
    **Azure API Gateway:** <br/>
    Used gateway for endpoints.
    
 # Assumptions:
    I added login endpoint.<br/>
    

 # Issues encountered:
    1- I struggled with how to parse medicine data. So, I tried different solutions but I failed. Then, <br/>
      I used pyhton pandas library and Its solved<br/>
    2- Queue service<br/>
    3- I have APIGateway but I url not working<br/>


# Data Model

    ![image](https://github.com/berk2k/se4458_final/blob/master/dm/se4458_dm.JPG)<br/>
# Video
https://se4458storageaccount.blob.core.windows.net/19070006043midtermvideo/19070006043_se4458midterm.mp4
