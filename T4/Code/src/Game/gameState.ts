import { GameState, InventoryItem } from "../types";

const gameState: GameState = {
    inventory: [],
    isThermostatAdded: false,
    isThermostatTaken: false,
    isThermostatToHospital: false,
    isWoodTaken: false,
    isWoodTransformed: false,
    isWoodNeeded: false,
    isBedroomChanged: false,
    areFurnitureNeeded: false,
    areFurnitureAdded: false,
    isSportsRoomFixed: false,
    isBedroomFixed: false,
    isDialogueHospitalReaded: false,
    isDialogueSportRoomReaded: false,
    isSportRoomWindowClosedOnce: false,
    hasTalkedToWorkshopPNJ: false,
};

const defaultGameState: GameState = {
    inventory: [],
    isThermostatToHospital: false,
    isThermostatAdded: false,
    isThermostatTaken: false,
    isWoodTaken: false,
    isWoodTransformed: false,
    isWoodNeeded: false,
    isBedroomChanged: false,
    areFurnitureNeeded: false,
    areFurnitureAdded: false,
    isDialogueHospitalReaded: false,
    isDialogueSportRoomReaded: false,
    isSportRoomWindowClosedOnce: false,
    isSportsRoomFixed: false,
    isBedroomFixed: false,
    hasTalkedToWorkshopPNJ: false,
};

export function resetGameState() {
    Object.assign(gameState, defaultGameState);
    gameState.inventory = gameState.inventory.filter(item => item.id !== 2);
    console.log("Game state reset to default");
}

export function getGameState() {
    return gameState;
}

export function addToInventory(item: InventoryItem) {
    if (!gameState.inventory.find(i => i.id === item.id)) {
        gameState.inventory.push(item);
    }
}

export function removeFromInventory(item: InventoryItem) {
    gameState.inventory = gameState.inventory.filter(i => i.id !== item.id);
}

export function hasBeenUsed(itemId: number){
    const item = gameState.inventory.find(i => i.id === itemId);
    if(item){
        item.usable = false;
    }
}

export function hasItemInInventory(itemId: number) {
    return !!gameState.inventory.find(i => i.id === itemId);
}

export function isItemUsable(itemId: number){
    const item = gameState.inventory.find(i => i.id === itemId);
    if(item){
        return item.usable;
    }else{
        return false;
    }
}

export function isBedroomFixed() {
    return gameState.isBedroomFixed;
}

export function setBedroomFixed(so: boolean) {
    gameState.isBedroomFixed = so;
}

export function isSportsRoomFix() {
    return gameState.isSportsRoomFixed;
}

export function setSportsRoomFix(so: boolean) {
    gameState.isSportsRoomFixed = so;
}

export function clearInventory() {
    console.log("Inventory cleared");
    gameState.inventory = [];
}

export function addThermostatToRoom() {
    gameState.isThermostatAdded = true;
}

export function isThermostatAddedToRoom() {
    return gameState.isThermostatAdded;
}

export function addFurnitureToRoom() {
    gameState.isBedroomChanged = true;
}

export function isFurnitureAddedToRoom() {
    return gameState.isBedroomChanged;
}

export function areFurnitureNeededGS() {
    return gameState.areFurnitureNeeded;
}

export function setAreFurnitureNeededGS(so: boolean) {
    gameState.areFurnitureNeeded = so;
}

export function areFurnitureAddedGS() {
    return gameState.areFurnitureAdded;
}

export function setAreFurnitureAddedGS(so: boolean) {
    gameState.areFurnitureAdded = so;
}


export function takeWood() {
    gameState.isWoodTaken = true;
}

export function isWoodTaken() {
    return gameState.isWoodTaken;
}

export function transformWood() {
    if (gameState.isWoodTaken) {
        gameState.isWoodTransformed = true;
    }
}

export function isWoodTransformed() {
    return gameState.isWoodTransformed;
}

export function setIsWoodTransformed() {
    gameState.isWoodTransformed = false;
}

export function getIsWoodNeeded() {
    return gameState.isWoodNeeded;
}

export function setIsWoodNeeded() {
    gameState.isWoodNeeded = !gameState.isWoodNeeded;
}

export function setThermostatToHospital() {
    gameState.isThermostatToHospital = true;
}

export function isThermostatToHospital(){
    return gameState.isThermostatToHospital
}

export function isDialogueHospitalReaded(){
    return gameState.isDialogueHospitalReaded;
}

export function isDialogueSportRoomReaded(){
    return gameState.isDialogueSportRoomReaded
}
export function isSportRoomWindowClosedOnce(){
    return gameState.isSportRoomWindowClosedOnce;
}

export function dialogueHospitalRead() {
    gameState.isDialogueHospitalReaded = true;
}
export function dialogueSportRoomRead() {
    gameState.isDialogueSportRoomReaded = true;
}
export function sportRoomWindowClosed() {
    gameState.isSportRoomWindowClosedOnce = true;
}

export function setHasTalkedToWorkshopPNJ(value: boolean) {
    gameState.hasTalkedToWorkshopPNJ = value;
}

export function hasTalkedToWorkshopPNJ() {
    return gameState.hasTalkedToWorkshopPNJ;
}