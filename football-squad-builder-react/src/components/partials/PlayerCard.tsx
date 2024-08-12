 import { Player } from '../../features/footballData-feature/types';



 function PlayerCard({ player }: { player: Player }) {
  return (
    <>
    <article className='player-card'>
        <div className='player-card-img-container'>
            <img className='player-card-img' src={player.imageURL} alt={`${player.name}'s image`} />
        </div>

        <div className='player-card-profile'>
                <h3>#{player.jerseyNumber} {player.name}</h3>
                <p>Age: {player.age}</p>
                <p>{player.position}</p>
        </div>
    </article>
    </>
  )
}

export default PlayerCard
