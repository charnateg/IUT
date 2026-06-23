import astrolabe from '../../assets/img/astrolabe.png';
import { useNavigate } from 'react-router-dom';
import { useMusic } from '../../context/MusicContext';

export default function Concordia() {
    const navigate = useNavigate();
    const { playMusic } = useMusic();

    const handleStartingGame = () => {
        playMusic(); // Lance la musique
        navigate('/base');
    };

    return (
        <div style={{ position: 'relative', width: '100vw', height: '100vh', overflow: 'hidden' }}>
            <img
                src={astrolabe}
                alt="concordia"
                style={{
                    width: '100%',
                    height: '100%',
                    objectFit: 'cover',
                    display: 'block',
                    opacity: 0.5
                }}
            />

            <div className="boxIntro">
                <h2 className="titleIntro">Bienvenue en Antarctique !</h2>
                <p className="textIntro">
                    Vous êtes un architecte sur le point d'entrer dans la station Concordia, un lieu de recherche scientifique unique situé au cœur de l'Antarctique.
                    Votre mission est de réhabiliter cette station qui, vous allez voir, n'a pas été pensée pour être un lieu de vie.
                    <br />
                    <br />
                    Vous allez devoir faire preuve de créativité et d'ingéniosité pour transformer cet environnement hostile en un espace accueillant et fonctionnel.
                    <br />
                    <br />
                    Préparez-vous à vivre une expérience inoubliable dans l'un des endroits les plus reculés de la planète.
                    <br />
                    <br />
                </p>
                <button onClick={handleStartingGame} className="buttonIntro">
                        Aller à Concordia
                </button>
            </div>

        </div>
    );
}