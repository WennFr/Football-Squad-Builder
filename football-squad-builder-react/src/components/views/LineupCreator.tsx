import React, { useState, useEffect } from 'react';
import footballField from '../../assets/football-field-1.jpg';
import { useCompetitions } from './hooks/useCompetitions';
import { useClubs } from './hooks/useClubs';
import { usePlayers } from './hooks/usePlayers';




function LineupCreator() {

    const { competitions, loading: competitionsLoading, error: competitionsError } = useCompetitions();
    const [selectedCompetition, setSelectedCompetition] = useState<string | null>(null);
    const { clubs, loading: clubsLoading, error: clubsError } = useClubs(selectedCompetition);
    const [selectedClub, setSelectedClub] = useState<string | null>(null);
    const { players, setPlayers, loading: playersLoading, error: playersError } = usePlayers(selectedClub);

    const isLoading = competitionsLoading || clubsLoading || playersLoading;


    useEffect(() => {
            setPlayers([]);
    }, [selectedCompetition]);


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
                        </div>
                        <div className='sidebar-players'>
                            <div className='sidebar-players-heading'>
                                <h2 >Players</h2>
                            </div>
                            <div className='sidebar-players-cards'>
                                {isLoading && (
                                    <div className='spinner'>
                                        <span className='loader'></span>
                                    </div>
                                )}
                                {!isLoading && players.length === 0 && !selectedClub && (
                                    <p>Select a club to see players</p>
                                )}
                                {!isLoading && players.length > 0 && (
                                    players.map((player) => (
                                        <ol key={player.id}>
                                            {player.jerseyNumber} {player.name}
                                        </ol>
                                    ))
                                )}
                            </div>
                        </div>
                    </aside>
                </div>
            </section>
        </>
    )
}

export default LineupCreator