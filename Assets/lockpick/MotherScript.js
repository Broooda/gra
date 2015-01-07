#pragma strict

static var good : int = 0;
static var reset : boolean = false;
static var now : int = 0;
static var order = new Array (3,5,1,2,4);
static var whichDone = new Array(5);

function Start(){
	for (var i = 0; i < whichDone.length; ++i) { whichDone[i] = false; }
	Shuffle(order);
}

function Update () {
	if(good==5){
		guiText.text='Brawo, udało Ci się!';
	}
	if(good<=order.length-1){
		now=order[good];
	}
	//Debug.Log("Good:"+good);
	//Debug.Log("ktore(NOW)"+now);
	Debug.Log('kolenosc reset'+order);
	//Debug.Log('WHICHdone'+whichDone);
}

function Shuffle(deck: Array) {
    for (var i : int = 0; i < deck.length; i++) {
        var temp = deck[i];
        var randomIndex = Random.Range(0, deck.length);
        deck[i] = deck[randomIndex];
        deck[randomIndex] = temp;
    }
}