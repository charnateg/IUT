import etage1 from "../../../assets/img/noisy_stage_1.png";
import {NavLink, useNavigate} from "react-router-dom";

export default function NoisyTowerStage1() {
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
            <img src={etage1} alt="noisystage1" />
            <NavLink to="/noisy_stage_one/workshop">
                <div className="click-zone" style={{ top: '322px', left: '103px', width: '192px', height: '80px' }} >
                </div>
            </NavLink>
        </>
    )
}