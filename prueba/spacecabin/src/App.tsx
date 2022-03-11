import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import { env } from './ServerData';
import { table } from 'console';

function App() {

    const [inputH, setInputH] = useState("");
    const [inputHE, setInputHE] = useState("");
    const [inputHID, setInputHID] = useState(0);

    const [ships, setShips] = useState([{
        id: 0,
        name: "",
        model: "",
        type: "",
        armor: 0,
        stamina: 0,
        power: 0,
        image: "",
        passengers: true,
        passengersLimit: 0,
        cargo: true,
        cargoLimit: 0
    }]);

    const getShips = async () => {

        const res = await fetch(env.server, {
            method: "GET", mode: 'cors'
        }).then((response) => {
            return response.json();
        });
        setShips(res);
    }

    const deleteShip = async (id: number) => {

        const res = await fetch(env.server + id, {
            method: "DELETE", mode: 'cors'
        }).then((response) => {
            return response.json();
        });
        if (res) {
            
        }
    }

    const ceateShip = async (name: string) => {
        const s = {
            id: Math.floor(Math.random() * (1000 - 1) + 1),
            name: name,
            model: "",
            type: "",
            armor: 0,
            stamina: 0,
            power: 0,
            image: "",
            passengers: true,
            passengersLimit: 0,
            cargo: true,
            cargoLimit: 0
        };

        const res = await fetch(env.server, {
            method: "POST", mode: 'cors',
            body: JSON.stringify(s),
            headers: {
                'Content-Type': 'application/json'
            },
        }).then((response) => {
            console.log(response);
            return response.json();
        });
        
    }

    const updateShip = async (id:number) => {
        const s = {
            id: id,
            name: inputHE,
            model: "",
            type: "",
            armor: 0,
            stamina: 0,
            power: 0,
            image: "",
            passengers: true,
            passengersLimit: 0,
            cargo: true,
            cargoLimit: 0
        };

        const res = await fetch(env.server+id, {
            method: "PUT", mode: 'cors',
            body: JSON.stringify(s),
            headers: {
                'Content-Type': 'application/json'
            },
        }).then((response) => {
            console.log(response);
            return response.json();
        });

    }

    useEffect(() => {
        getShips();
    }, []);
    
    const handleInput = (e) => {
        setInputH(e.target.value);
    }

    const handleInputE = (e) => {
        setInputHE(e.target.value);
    }

    return (

        <>
            <div>
                <h3>Crear</h3>
                Nombre <input value={inputH} onChange={handleInput} />
                <button onClick={() => { ceateShip(inputH) }}>Crear</button>

                <h3>Editar</h3>
                Nombre <input value={inputHE} onChange={handleInputE} />
                <button onClick={() => { updateShip(inputHID) }}>Guardar</button>
            </div>
            <br/>
            <br />
            <h3>Datos</h3>
            <table className="min-w-full leading-normal shadow-md border-gray-500 max-h-1.5 animate-fadeIn">
                <thead className="bg-gray-500 text-white">
                    <tr>
                        <th scope="col" className="">ID</th>
                        <th scope="col" className="">Nombre</th>
                        <th scope="col" className="">Acciones</th>
                    </tr>
                </thead>
                <tbody className="h-3/5">
                    {
                        ships.map(ship => {
                            const bg = ship.id === 0 ? '' : 'bg-red-600 px-2 py-1 my-2 text-white rounded-md';
                            return (
                                <tr key={ship.id} id={ship.id.toString()}>
                                    <td className="">
                                        <p className="">{ship.id}</p>
                                    </td>
                                    <td className="">
                                        <p className="">
                                            {ship.name}
                                        </p>
                                    </td>
                                    <td className="">
                                        <button onClick={() => { setInputHE(ship.name); setInputHID(ship.id); }}>Editar</button>
                                        <button onClick={() => { deleteShip(ship.id) }}>Eliminar</button>
                                    </td>

                                </tr>
                            )
                        })
                    }
                </tbody>
            </table>
        </>
    );
}

export default App;
