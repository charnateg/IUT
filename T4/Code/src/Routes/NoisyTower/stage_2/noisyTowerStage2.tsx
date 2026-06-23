import etage2 from "../../../assets/img/noisy_stage_2.png";
import {NavLink, useNavigate} from "react-router-dom";

export default function NoisyTowerStage2() {
    const navigate = useNavigate();

    function handleGoBack() {
        navigate("/base");
    }

    return (
        <>
            <button
                onClick={handleGoBack}
                style={{
                    position: "absolute",
                    top: "10px",
                    left: "45%",
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
            <img src={etage2} alt="noisystage2" />
            <NavLink to="/noisy_stage_two/sportsroom">
                <div className="click-zone" style={{ top: '730px', left: '201px', width: '215px', height: '90px' }} >
                </div>
            </NavLink>
        </>
    )
}