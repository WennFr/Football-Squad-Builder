 import { Player } from '../../features/footballData-feature/types';



 function PlayerCard({ player }: { player: Player }) {
  return (
    <>
    <div className='playerCard'>
      <h3>{player.jerseyNumber} - {player.name}</h3>
    </div>
    </>
  )
}

export default PlayerCard
