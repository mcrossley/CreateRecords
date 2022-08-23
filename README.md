# CreateRecords
A utility to update or create missing records entries from the Cumulus MX dayfile.txt

## About this program
The CreateRecords utility is a command program written in .Net Framework, so it will run on Windows or Linux. Under Linux you will have to use the mono runtime environment to execute the program.

The utility will read your dayfile.txt. It will then extract all the relevant records and write them to the appropriate records xxxx.ini files for Culumus MX to use

### Data Accuracy
The record values created by CreateRecords are only as good as the source data in the dayfile.

## Installing
Just copy the two files (CreateRecords.exe, CreateRecords.exe.config) in the release zip file to your Cumulus MX root folder.

## Before you run CreateRecords
You should first run the CreateMissing utility which will add missing data to existing dayfile entries, and recreate missing days from the dayfile if the corresponding monhtly log files are available.

You should then sanity check the the dayfile for any obviously incorrect entries before running CreateRecords.

CreateRecords also uses your Cumulus.ini file to determine things like when your meteorological day starts, and what units you use for your measurements. So make sure you have all this configured correctly in Cumulus MX before importing data into a new install.

## Running CreateRecords
From Windows, start a command prompt and change the path to your Cumulus MX root folder. Then enter the command:

` > CreateRecords.exe`

From Linux, change your command line path to your Cumulus MX root folder, then enter the command:

` > mono CreateRecords.exe`

## Output
If the utility runs successfully your original records files will be saved as data\alltime.ini.sav etc

If the saved file is already present, CreateRecords will not overwrite it. An error message will be output for that file. You should rename or save the backup file somewhere else before running CreateRecords again.

In addition to the information output to the console, each run of CreateRecords will create a new log file in your MXdiags folder. You may need to refer to that file when fixing up issues with your monthly log files.

The records files updated are:

`alltime.ini, month.ini, monthlyalltime.ini, year.ini`

## Cumulus MX
Please note that you should NOT run CreateRecords without first stopping Cumulus MX.

