@ECHO OFF
setlocal
set folderpath="C:\Users\fayt64\AppData\Roaming\7DaysToDie\Mods"
set foldermod="C:\Users\fayt64\AppData\Roaming\7DaysToDie\Mods\tbm-mod-a21"
set foldergithubrepo="C:\github\TBM_7dmod\tbm-mod-a21"

REM --- Check if this folder exist
if exist %folderpath%\ (  
  echo 7days mod folder exists.
) else (
  GOTO END
)

if exist %foldergithubrepo%\ (  
  echo github repo folder exists.
) else (
  GOTO END
)

REM -- Should we delete an old mod install?
if exist %foldermod%\ (
  GOTO DELETING_FOLDER
) else (
  GOTO COPY_MODFOLDER
)


:DELETING_FOLDER
echo Deleting folder %foldermod% ?
@RD /s /q %foldermod% 
mkdir %foldermod%



:COPY_MODFOLDER
echo Copying from github repo to to modfolder
robocopy /e %foldergithubrepo% %foldermod%
 

:END
echo Ending
endlocal


pause