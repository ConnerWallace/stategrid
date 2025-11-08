import sqlite3




connection = sqlite3.connect("stateinfo.db")

cursor = connection.cursor()

#this table needs to exist first 
#possibleCategories = cursor.execute("SELECT name, clause FROM categories").fetchall()

#randomly select possibleCategories

listOfStates = cursor.execute("SELECT name FROM STATES") .fetchall() 
#needed cuz fetchall is returning a list of tuples
states = list(map( lambda x: x[0], listOfStates))

print(states)

