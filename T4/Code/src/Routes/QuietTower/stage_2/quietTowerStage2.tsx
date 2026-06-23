import stage2 from "../../../assets/img/quiet_stage_2.png";
import {NavLink, useNavigate} from "react-router-dom";
import "../css/quietstages.css"

export default function QuietTowerStage2() {
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
            <img src={stage2} alt="quiet_stage_2"/>
            <NavLink to="/quiet_stage_two/bedrooms">
                <div className="click-zone" style={{ top: '160px', left: '305px', width: '318px', height: '110px' }} >
                </div>
            </NavLink>
        </>
    );
}