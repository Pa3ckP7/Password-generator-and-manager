# Password-generator-and-manager
This is only an exercise project and is not perfectly safe. Use at your own risk.
#
Filters need to be manually created. You can create one by creating a txt file. In the text file write every allowed character/symbol
you want the filter to include. At the end put the txt file in Saved_data\Filters which is automatically created during the 1st lunch
where the exe is.
Filters can also be installed during runtime
Within the app you refer to filters only by their name and without the file extension
#
Passwords are all encrypted and stored nowhere else than locally in Saved_data folder and can onyl be decrypted with the decryption_key
if the key, the Saved_data\passwords directory or any file within the directory is lost/deleted the password is lost forever.
