
export type Place = {
    id: number;
    name: String;
}

export type Problem = {
    id: number;
    place: Place;
    where: String;
}

export type Item = {
    name: String;
    usable: Boolean;
}

export type Inventory = {
    content: Item[];
}

export type Stat = {
        id: number;
        name: String;
        value: number;

}

export interface InventoryItem {
    id: number;
    name: string;
    usable: Boolean;
    description?: string;
}
  
export interface GameState {
    inventory: InventoryItem[];
    isThermostatAdded: boolean;
    isThermostatToHospital: boolean;
    isThermostatTaken: boolean;
    isWoodTaken: boolean;
    isWoodTransformed: boolean;
    isWoodNeeded: boolean;
    isBedroomChanged: boolean;
    areFurnitureNeeded: boolean;
    isDialogueHospitalReaded: boolean;
    isDialogueSportRoomReaded: boolean;
    isSportRoomWindowClosedOnce: boolean;
    areFurnitureAdded: boolean;
    isSportsRoomFixed: boolean;
    isBedroomFixed: boolean;
    hasTalkedToWorkshopPNJ: boolean;
}
