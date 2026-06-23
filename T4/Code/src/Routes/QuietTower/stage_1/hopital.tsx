import pnj from "../../../assets/img/pnj.png";
import hopital from "../../../assets/img/hopital.png";
import hopitalSansBois from "../../../assets/img/hopital_sans_bois.png";
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import {
    takeWood,
    isWoodTaken,
    areFurnitureNeededGS,
    isThermostatToHospital,
    hasItemInInventory,
    isItemUsable,
    isDialogueHospitalReaded,
    hasBeenUsed
} from "../../../Game/gameState.ts";

export default function Hopital() {
    const navigate = useNavigate();
    const [isThermostatPlaced, setIsThermostatPlaced] = useState(isThermostatToHospital());
    const [isDialogueReaded, setDialogue] = useState(isDialogueHospitalReaded());
    const [woodTaken, setWoodTaken] = useState(isWoodTaken());

    function handleTakeWood() {
        takeWood();
        setWoodTaken(true); // Met à jour l'état local
        alert("Bien, maintenant je vais pouvoir couper ces planches de bois pour aménager ces chambres !");
    }

    function handleGoBack() {
        navigate("/quiet_stage_one");
    }

    function handleDialogue() {
        if(isDialogueReaded&&hasItemInInventory(1)&&isItemUsable(1)) {
            alert("Oh mais c'est un thermostat ! Nos patient seront soigné dans de bien meilleurs conditions. ")
            hasBeenUsed(1);
            setIsThermostatPlaced(true);
        }else if(isThermostatPlaced){
            alert("Encore merci pour ce thermostat, les patients vous remercie tous")
        }else if(isWoodTaken()){
            alert("L'isolement de la pièce est réduit à cause du bois manquant ! Les blessés ont froid, si seulement nous avions un thermostat...");
            setDialogue(true);

        }else {
            alert("Ici c'est l'hôpital, et comme vous pouvez le voir, il n'y a AUCUN soucis de conception architecturale, et certainement pas ces murs en bois")
        }
    }

    return (
        <>
            <button
                onClick={handleGoBack}
                style={{
                    position: "absolute",
                    top: "10px",
                    left: "50%",
                    transform: "translateX(-50%)",
                    padding: "10px 20px",
                    backgroundColor: "#28A745",
                    color: "#fff",
                    border: "none",
                    borderRadius: "5px",
                    cursor: "pointer",
                }}>
                Retour
            </button>
            <img src={woodTaken ? hopitalSansBois : hopital} alt="hopital"/>
            <img
                src={pnj}
                alt="PNJ"
                style={{
                    cursor: 'pointer',
                    position: "absolute",
                    bottom: "30%", // Position verticale fixe
                    transform: "scaleX(-1)",
                    left: "36%", // Position horizontale dynamique
                    height: "33%",
                    zIndex: 1000, // Assure que le manchot est au premier plan
                }}
                onClick={handleDialogue}
            />
            {!woodTaken && areFurnitureNeededGS() && (
                <button
                    onClick={handleTakeWood}
                    style={{
                        position: "absolute",
                        top: "50%",
                        left: "50%",
                        transform: "translate(-50%, -50%)",
                        padding: "10px 20px",
                        backgroundColor: "#007BFF",
                        color: "#fff",
                        border: "none",
                        borderRadius: "5px",
                        cursor: "pointer",
                    }}>
                    Prendre le bois
                </button>
            )}
        </>
    );
}