import React, { useState, useEffect } from 'react';
import footballField from '../../assets/football-field-1.jpg';
import { useCompetitions } from './hooks/useCompetitions';
import { useClubs } from './hooks/useClubs';
import { usePlayers } from './hooks/usePlayers';
import PlayerCard from '../partials/PlayerCard';
import FieldPlayer from '../partials/FieldPlayer';
import { Player } from '../../features/footballData-feature/types';
import { DragDropContext, Droppable, Draggable, DropResult, DroppableProps } from 'react-beautiful-dnd';


function LineupCreator() {

    const { competitions, loading: competitionsLoading, error: competitionsError } = useCompetitions();
    const [selectedCompetition, setSelectedCompetition] = useState<string | null>(null);
    const { clubs, loading: clubsLoading, error: clubsError } = useClubs(selectedCompetition);
    const [selectedClub, setSelectedClub] = useState<string | null>(null);
    const { players, setPlayers, loading: playersLoading, error: playersError } = usePlayers(selectedClub);

    const [fieldPlayers, setFieldPlayers] = useState<Player[]>([]);

    const isLoading = competitionsLoading || clubsLoading || playersLoading;

    useEffect(() => {
        setPlayers([]);
    }, [selectedCompetition]);


    const onDragEnd = (result: DropResult) => {
        const { source, destination, draggableId } = result;
        console.log('Drag End:', result); // Debugging

        // Dropped outside any droppable area
        if (!destination) {
            console.log('Dropped outside any droppable area');
            return;
        }
        console.log('Destination:', destination.droppableId);
        console.log('Source:', source.droppableId);

        if (destination.droppableId === 'field' && source.droppableId === 'players') {
            console.log('Player dropped on field:', draggableId);

            if (fieldPlayers.length < 11) {
                const player = players.find(p => p.id === draggableId);

                if (player != null) {
                    setFieldPlayers((prev) => {
                        if (!prev.some(p => p.id === draggableId)) {
                            return [...prev, player];
                        }
                        return prev;
                    });

                    setPlayers(prev => prev.filter(p => p.id !== draggableId));
                }
            }
        }

        else if (destination.droppableId === 'players' && source.droppableId === 'field') {
            console.log('Player dropped in players list:', draggableId);

            const player = fieldPlayers.find(p => p.id === draggableId);

            if (player != null) {

                setPlayers(prevPlayers => {
                    const reorderedPlayers = Array.from(prevPlayers);
                    // Insert the player at the correct index in the players list
                    reorderedPlayers.splice(destination.index, 0, player);
                    return reorderedPlayers;
                });

                // Remove player from the field
                setFieldPlayers((prev) => prev.filter(p => p.id !== draggableId));
            }
        }

        else if (destination.droppableId === 'players' && source.droppableId === 'players') {
            const reorderedPlayers = Array.from(players);
            const [removed] = reorderedPlayers.splice(result.source.index, 1);
            reorderedPlayers.splice(destination.index, 0, removed);
            setPlayers(reorderedPlayers);
        }

        else if (destination.droppableId === 'field' && source.droppableId === 'field') {
            const reorderedPlayers = Array.from(fieldPlayers);
            const [removed] = reorderedPlayers.splice(result.source.index, 1);
            reorderedPlayers.splice(destination.index, 0, removed);
            setFieldPlayers(reorderedPlayers);
        }

    };

    return (
        <>
            <section className='lineup'>
                <div className='heading'>
                    <h1>Lineup Creator</h1>
                </div>
                <DragDropContext onDragEnd={onDragEnd}>
                    <div className='lineup-creator'>
                        <Droppable
                            droppableId="field"
                            type="players"
                        >
                            {(provided) => (
                                <div
                                    ref={provided.innerRef}
                                    {...provided.droppableProps}
                                    className="football-field"
                                    style={{ backgroundImage: `url(${footballField})` }}
                                >
                                    <ul className='lineup'>
                                        {fieldPlayers.map((player, index) => (
                                            <Draggable key={player.id} draggableId={player.id} index={index}>
                                                {(provided) => (
                                                    <li
                                                        ref={provided.innerRef}
                                                        {...provided.draggableProps}
                                                        {...provided.dragHandleProps}
                                                        style={{ ...provided.draggableProps.style }}
                                                    >

                                                        <FieldPlayer key={player.id} player={player!} />
                                                    </li>
                                                )}
                                            </Draggable>
                                        ))}
                                        {provided.placeholder}
                                    </ul>
                                </div>
                            )}
                        </Droppable>
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
                                <Droppable
                                    droppableId="players"
                                    type="players"
                                >
                                    {(provided) => (
                                        <ul
                                            className='sidebar-players-cards'
                                            ref={provided.innerRef}
                                            {...provided.droppableProps}
                                        >
                                            {isLoading && (
                                                <div className='spinner'>
                                                    <span className='loader'></span>
                                                </div>
                                            )}
                                            {!isLoading && players.length === 0 && !selectedClub && (
                                                <p>Select a club to see players</p>
                                            )}
                                            {!isLoading && players.length > 0 && (
                                                players.map((player, index) => (
                                                    <Draggable key={player.id} draggableId={player.id} index={index}>
                                                        {(provided) => (
                                                            <li
                                                                ref={provided.innerRef}
                                                                {...provided.draggableProps}
                                                                {...provided.dragHandleProps}
                                                                style={{ ...provided.draggableProps.style }} // Optional: to remove bullet points
                                                            >
                                                                <PlayerCard key={player.id} player={player} />
                                                            </li>
                                                        )}
                                                    </Draggable>
                                                ))
                                            )}
                                            {provided.placeholder}
                                        </ul>
                                    )}
                                </Droppable>
                            </div>
                        </aside>
                    </div>
                </DragDropContext>
            </section>
        </>
    )
}

export default LineupCreator