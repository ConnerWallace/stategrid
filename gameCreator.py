import sqlite3
import random


def allUnique(x):
     seen = set()
     return not any(i in seen or seen.add(i) for i in x)

def CheckIfSolvable(l):
    ass =list(set(l[0]) & set(l[3]))
    bs = list(set(l[1]) & set(l[3]))
    cs = list(set(l[2]) & set(l[3]))
    ds = list(set(l[0]) & set(l[4]))
    es = list(set(l[1]) & set(l[4]))
    fs = list(set(l[2]) & set(l[4]))
    gs = list(set(l[0]) & set(l[5]))
    hs = list(set(l[1]) & set(l[5]))
    iss =list(set(l[2]) & set(l[5]))


    """
    print(ass)
    print(bs)
    print(cs)
    print(ds)
    print(es)
    print(fs)
    print(gs)
    print(hs)
    print(iss)
    """
    for a in ass:
        for b in bs:
            for c in cs:
                for d in ds:
                    for e in es:
                        for f in fs:
                            for g in gs:
                                for h in hs:
                                    for i in iss:
                                        
                                        if allUnique([a,b,c,d,e,f,g,h,i]):
                                            print([a,b,c,d,e,f,g,h,i])
                                            return True
                                            
    return False


connection = sqlite3.connect("stateinfo.db")

cursor = connection.cursor()

#this table needs to exist first 
possibleCategories = cursor.execute("SELECT id, name, clause, modifier FROM categories WHERE clause is not null and (modifier != 'x' or modifier is null)").fetchall()
#possibleCategories.pop()

#randomly select possibleCategories
while True:
    categories = random.sample(possibleCategories, 6)
    allAnswers = []

    mods = []
    names = []
    for category in categories:
        #print(category)
        listOfStates = cursor.execute(str(category[2])).fetchall()
        states = list(map( lambda x: x[0], listOfStates))
        mods.append(category[3])
        names.append(category[1])
        allAnswers.append(states)
        

    mods1 = mods[0:3]
    mods2 = mods[3:6]
    mods1 = [item for item in mods1 if item is not None]
    mods2 = [item for item in mods2 if item is not None]


    if(any("Largest City s" in x for x in names) and random.randint(1,4) < 4):
        #print("rejecting list cause it has Largest City starts with")
        continue
    
    if(any("Largest City e" in x for x in names) and random.randint(1,4) < 4):
        #print("rejecting list cause it has Largest City ends")
        continue

    if(any("Capital e" in x for x in names) and random.randint(1,4) < 3):
        #print("rejecting list cause it has Capital starts with")
        continue
    
    if(any("Capital s" in x for x in names) and random.randint(1,4) < 3):
        #print("rejecting list cause it has Capital ends with")
        continue

    
    if not (allUnique(mods1) and allUnique(mods2)) :
        continue

    if CheckIfSolvable(allAnswers):
        print("foudn one")
        cursor.execute("insert into games values(?,?,?,?,?,?, null)", [categories[0][0] , categories[1][0] , categories[2][0] , categories[3][0] , categories[4][0] , categories[5][0]])
        connection.commit()
