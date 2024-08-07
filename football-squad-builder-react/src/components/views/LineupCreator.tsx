import React, { useEffect, useState } from 'react';
import footballField from '../../assets/football-field-1.jpg';
import { fetchCompetitions } from '../../features/footballData-feature/api/competitionApi';
import { Competition } from '../../features/footballData-feature/types';



function LineupCreator() {

    const [competitions, setCompetitions] = useState<Competition[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const loadCompetitions = async () => {
            try {
                const data = await fetchCompetitions();
                setCompetitions(data);
                setLoading(false);
            } catch (err) {
                if (err instanceof Error) {
                    setError(err.message);
                } else {
                    setError('An unknown error occurred');
                }
                setLoading(false);
            }
        };

        loadCompetitions();
    }, []);

    return (
        <>
            <section className='lineup'>
                <div className='heading'>
                    <h1>Lineup Creator</h1>
                </div>
                <div className='lineup-creator'>
                    <div className="football-field" style={{ backgroundImage: `url(${footballField})` }}></div>
                    <aside className='sidebar'>
                        <div className='sidebar-nav'>
                            <select className='search-dropdown'>
                                <option value="">Select League</option>
                                {competitions.map((competition) => (
                                    <option key={competition.id} value={competition.id}>
                                        {competition.name}
                                    </option>
                                ))}
                            </select>
                            <select className='search-dropdown'>
                                <option value="">Select Club</option>
                                <option value="club1">Club 1</option>
                                <option value="club2">Club 2</option>
                                {/* Add more clubs as needed */}
                            </select>
                            <select className='search-dropdown'>
                                <option value="">Select Player</option>
                                <option value="player1">Player 1</option>
                                <option value="player2">Player 2</option>
                                {/* Add more players as needed */}
                            </select>
                        </div>
                        <div className='sidebar-section'>
                            <h2>Players</h2>
                            <ol>

                            </ol>
                        </div>
                    </aside>
                </div>
            </section>
        </>
    )
}

export default LineupCreator