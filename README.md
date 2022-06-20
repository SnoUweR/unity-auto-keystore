## Auto Keystore

This utility automatically sets the Android keystore data (alias name, alias password, keystore password) after project reopening.

How to make it work:
1. Set keystore credentials in the "Top Menu -> Window -> Auto Keystore..." window.
2. Click the "Enabled" checkbox in the window.

### Warning
The credentials are stored in the EditorPrefs file. Anyone that has access to your computer can open this file.
Despite the fact that the data is encrypted using XOR, this encryption method can be cracked.