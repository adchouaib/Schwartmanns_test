## To run the application :

- If you have Docker installed, follow these steps to run the application:

  1. Navigate to the root folder of the project
  2. Run the following command:
     `docker compose up`

- If Docker is not installed on your laptop, follow these alternative steps:

  1. Navigate to WebApi > WebApi > appsettings.json and modify the connection string to your localdb connection string.
  2. Create an environment variable using Visual Studio:

     - Right-click on the WebAPi project
     - Go to Properties > Debug.
     - Create an environment variable named SECRET_KEY with the value: "this is my custom Secret key for authentication".

  3. Run the WebApi project.
  4. Navigate to the Website folder and run the following command in the terminal \
     `npm run dev`

These steps will help you run the application successfully, whether you have Docker installed or not
