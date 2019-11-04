# DeskNotes - By MnApps.NET
Desknotes was created as a helping tool for my work. 
Many times you need to access your notepad quicky to keep a note or
do some calculations on the side. That is what Desknotes was made to serve.
It is a note area with commands for quick and easy note taking.

# Functionality :
* Middle click on the arrow when it is pointing left to keep it on the top of every windows
* Right click on the arrow when it is pointing left to restart the program
* Left click on the arrow when it is pointing left to show the note area
* Middle click on the arrow when it is pointing right to close the program
* Use shortcuts _Left_Control_ + _Left_Shift_ + _A_ OR _D_ to open and close the panel (A : Open, D : Close)
  you can change the shortcut buttons from from the Variables Region of Main.cs

# Commands : 
Commands are text commands you can type to get some results quickly on your notes,
you can see below the list of all available commands as for now.

* Numeric expression calculations : \<SM\>expression; expression can contain : [1-9]+-/*^(),.
* Get Formated Date               : \<SM\>DD.MM.YY;  OR  \<SM\>MM.DD.YYYY;  OR any variation of the three
* Get Full Date                   : \<SM\>date;
* Get Time                        : \<SM\>time;  
* Style text                      : \<SM\>/ST TEXT /ST; where ST={b,i,u,s,p} with b = bold, i = italic, u = underline, s = strike out, p = protected text
* Open process                    : \<SM\>P:PROCESS; where PROCESS is a process name
  Using this command you can create new process names and link them with an executable. If no executable is linked to a process
  name you entered the program askes you to link one. To delete link add .d at the end of a command like so : \<SM\>P:PROCESS.d;
* Search the internet			  : \<SM\>S:SEARCH_STRING; where SEARCH_STRING is a string you will use as a search term on google

 *\<SM\> is special command symbol that can be set on the program*
