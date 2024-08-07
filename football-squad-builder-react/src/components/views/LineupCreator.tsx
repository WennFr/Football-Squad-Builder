import React, { useState } from 'react';
import footballField from '../../assets/football-field-1.jpg';
import { useCompetitions } from './hooks/useCompetitions';
import { useClubs } from './hooks/useClubs';



function LineupCreator() {

    const { competitions, loading: competitionsLoading, error: competitionsError } = useCompetitions();
    const [selectedCompetition, setSelectedCompetition] = useState<string | null>(null);
    const { clubs, loading: clubsLoading, error: clubsError } = useClubs(selectedCompetition);
    const [selectedClub, setSelectedClub] = useState<string | null>(null);

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
                            <select 
                                className='sidebar-dropdown'
                                onChange={(e) => setSelectedCompetition(e.target.value)}
                                value={selectedCompetition || ''}
                            >
                                <option value="">Select League</option>
                                {competitions.map((competition) => (
                                    <option key={competition.id} value={competition.id}>
                                        {competition.name}
                                    </option>
                                ))}
                            </select>
                            <select 
                                className='sidebar-dropdown'
                                onChange={(e) => setSelectedClub(e.target.value)}
                                value={selectedClub || ''}
                            >
                                <option value="">Select Club</option>
                                {clubs.map((club) => (
                                    <option key={club.id} value={club.id}>
                                        {club.name}
                                    </option>
                                ))}
                            </select>
                            <select className='sidebar-dropdown'>
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