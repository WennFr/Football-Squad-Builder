import footballField from '../../assets/football-field-1.jpg';

function LineupCreator() {
    return (
        <>
            <section className='lineup'>

                <div className='heading'>
                    <h1>Lineup Creator</h1>
                </div>

                <div className='lineup-creator'>

                    <div className="football-field" style={{ backgroundImage: `url(${footballField})` }}></div>

                    <aside className='sidebar'>
                        <div className='sidebar-section'>
                            <h2>Players</h2>


                        </div>

                    </aside>


                </div>

            </section>

        </>
    )
}

export default LineupCreator