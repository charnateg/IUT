import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import { BrowserRouter, Route, Routes, useLocation } from 'react-router-dom';
import './index.css';
import App from './App.tsx';
import QuietTowerStage1 from './Routes/QuietTower/stage_1/quietTowerStage1.tsx';
import QuietTowerStage2 from './Routes/QuietTower/stage_2/quietTowerStage2.tsx';
import QuietTowerStage3 from './Routes/QuietTower/stage_3/quietTowerStage3.tsx';
import Workshop from './Routes/NoisyTower/stage_1/workshop.tsx';
import SportsRoom from './Routes/NoisyTower/stage_2/sportsRoom.tsx';
import NoisyTowerStage3 from './Routes/NoisyTower/stage_3/noisyTowerStage3.tsx';
import NoisyTowerStage1 from "./Routes/NoisyTower/stage_1/noisyTowerStage1.tsx";
import NoisyTowerStage2 from "./Routes/NoisyTower/stage_2/noisyTowerStage2.tsx";
import Chambre from "./Routes/QuietTower/stage_2/bedroom.tsx";
import Hopital from "./Routes/QuietTower/stage_1/hopital.tsx";
import Laboratory from "./Routes/QuietTower/stage_3/laboratory.tsx";
import NuclearBan from "./Routes/NuclearBan";
import GamesRoom from "./Routes/NoisyTower/stage_3/gamesroom.tsx";
import Concordia from "./Routes/Concordia/concordia.tsx";
import Penguin from './components/penguin.tsx'; // Import du composant Penguin
import BackgroundMusic from "./components/backgroundMusic";
import { MusicProvider } from "./context/MusicContext";


function PenguinWrapper() {
    const location = useLocation();
    return location.pathname === "/base" ? <Penguin /> : null; // Affiche le manchot uniquement sur /base
}

createRoot(document.getElementById('root')!).render(
    <StrictMode>
        <BrowserRouter>
            <MusicProvider> {/* MusicProvider enveloppe toute l'application */}
                <BackgroundMusic /> {/* Ajout de la musique de fond */}
                <PenguinWrapper />
                <Routes>
                    <Route path="/" element={<Concordia />} />
                    <Route path="base" element={<App />} />
                    <Route path="quiet_stage_one" element={<QuietTowerStage1 />} />
                    <Route path="quiet_stage_one/hospital" element={<Hopital />} />
                    <Route path="quiet_stage_two" element={<QuietTowerStage2 />} />
                    <Route path="quiet_stage_two/bedrooms" element={<Chambre />} />
                    <Route path="quiet_stage_three" element={<QuietTowerStage3 />} />
                    <Route path="quiet_stage_three/laboratories" element={<Laboratory />} />
                    <Route path="noisy_stage_one" element={<NoisyTowerStage1 />} />
                    <Route path="noisy_stage_one/workshop" element={<Workshop />} />
                    <Route path="noisy_stage_two" element={<NoisyTowerStage2 />} />
                    <Route path="noisy_stage_two/sportsroom" element={<SportsRoom />} />
                    <Route path="noisy_stage_three" element={<NoisyTowerStage3 />} />
                    <Route path="noisy_stage_three/gamesroom" element={<GamesRoom />} />
                    <Route path="/nuclear_ban" element={<NuclearBan />} />
                </Routes>
            </MusicProvider>
        </BrowserRouter>
    </StrictMode>
);