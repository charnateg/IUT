import chambre from "../../../assets/img/chambre.png";
import chambreOpti from "../../../assets/img/chambre_opti.png";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { areFurnitureAddedGS, isWoodTransformed, setAreFurnitureAddedGS, setAreFurnitureNeededGS, setBedroomFixed } from "../../../Game/gameState.ts";

export default function Bedroom() {
    const navigate = useNavigate();
    const [areFurnitureAdded, setAreFurnitureAdded] = useState(areFurnitureAddedGS());

    function handleGoBack() {
        navigate("/quiet_stage_two");
    }

    function handleAddFurniture() {
        setAreFurnitureAddedGS(true);
        setAreFurnitureAdded(areFurnitureAddedGS());
        setBedroomFixed(true);
    }

    function handleClue() {
        setAreFurnitureNeededGS(true);
        alert("Cette chambre n'est pas optimisée pour l'hivernage. Il faut optimiser l'utilisation de l'espace. Les hivernants aiment bricoler des meubles en bois. Je devrais peut-être faire de même ?");
    }

    return (
        <div style={{ position: "relative", width: "100vw", height: "100vh", overflow: "hidden" }}>
            <img 
            src={areFurnitureAdded ? chambreOpti : chambre} 
            alt={areFurnitureAdded ? "Chambre Optimisée" : "Chambre"}
            />
            {!areFurnitureAdded && (
                <button 
                    onClick={handleClue}
                    style={{
                        position: "absolute",
                        top: "50%",
                        left: "50%",
                        transform: "translate(-50%, -50%)",
                        padding: "10px 20px",
                        backgroundColor: "#FF5733",
                        color: "#fff",
                        border: "none",
                        borderRadius: "5px",
                        cursor: "pointer",
                    }}
                    > 🔎 </button>
            )}
            {!areFurnitureAdded && isWoodTransformed() && (
                <button 
                    onClick={handleAddFurniture}
                    style={{
                        position: "absolute",
                        top: "50%",
                        left: "75%",
                        transform: "translate(-50%, -50%)",
                        padding: "10px 20px",
                        backgroundColor: "#FF5733",
                        color: "#fff",
                        border: "none",
                        borderRadius: "5px",
                        cursor: "pointer",
                    }}
                    > 🔨 </button>
            )}
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
        </div>
    );
}