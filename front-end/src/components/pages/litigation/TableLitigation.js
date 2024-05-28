import 'bootstrap/dist/css/bootstrap.min.css';
import { useEffect, useState, useRef, useCallback } from 'react';
import * as React from "react";
import { useDispatch, useSelector, useStore } from 'react-redux';
import { Button, Col, Row, FormLabel } from "react-bootstrap";
import { AgGridReact } from 'ag-grid-react'; // AG Grid Component
import "ag-grid-community/styles/ag-grid.css"; // Mandatory CSS required by the grid
import "ag-grid-community/styles/ag-theme-quartz.css"; // Optional Theme applied to the grid
import { getLitigation, deleteLitigation } from '../../../redux/actions/actionLitigation';
import Swal from "sweetalert2";

export default function TableLitigation({ showForm, idUserEdit }) {

  const [userSelected, setUserSelected] = React.useState(false);
  const [selectedState, setSelectedState] = React.useState({});

  // Rellenar grid con datos
  const dispatch = useDispatch();
  const { litigations } = useSelector((state) => state.getLitigation);


  // Obtener la id del usuario. 
  const [id, setId] = useState(0);
  const gridRef = useRef();
  const onSelectionChanged = useCallback(() => {
    const selectedRows = gridRef.current.api.getSelectedRows();
    document.querySelector("#selectedRows").innerHTML =
      selectedRows.length === 1 ? selectedRows[0].procedimiento : "";
    console.log(selectedRows[0].idLitigio);
    setId(selectedRows[0].idLitigio);
    console.log(id)

  }, []);



  useEffect(() => {
    dispatch(getLitigation());
    console.log(litigations);
  }, [dispatch]);

  // Column Definitions: Defines the columns to be displayed.
  const [colDefs, setColDefs] = useState([
    { field: 'idLitigio', headerName: 'ID de Litigio' },
    { field: 'procedimiento', headerName: 'Procedimiento' },
    { field: 'juzgado', headerName: 'Juzgado' },
    { field: 'expediente', headerName: 'Expediente' },
    { field: 'edoJuzgado', headerName: 'Estado Juzgado' },
    { field: 'adeudoTotal', headerName: 'Adeudo Total' }
  ]);


  const handleNew = () => {
    showForm();
    idUserEdit(0);
  };

  // const handleEdit = () => {
  //   if (id) {
  //     idUserEdit(id);
  //     showForm();
  //   } else {
  //     alert('Seleccione un usuario para modificar');
  //   }
  // };

  const handleEdit = () => {
      console.log(id);
      if(id){
          showForm();
      }else{
          alert('Seleccione un Litigo para modificar');
      }
  };

  const handleDelete = () => {

    if (id) {
      // Eliminar usuario seleccionado
      dispatch(deleteLitigation(id)).then(() => {
        Swal.fire({
          icon: "success",
          title: "Litigo eliminado",
          showConfirmButton: false,
          timer: 1500,
        }).then(() => {
          dispatch(getLitigation());
        });
      });
    } else {
      Swal.fire({
        icon: "error",
        title: "Error",
        text: "Seleccione un Litigop para eliminar",
      });
      }
    // console.log(id);
    // if (id) {
    //   // Eliminar usuario seleccionado
    //   dispatch(deleteRealState(id))
    //     .then(() => {
    //       window.location.href = window.location.href;
    //     })
    // } else {
    //   alert("Seleccione un usuario para eliminar");
    // }
  };


  // ...

  return (

    // wrapping container with theme & size
    <div
      className="ag-theme-quartz" // applying the grid theme
      style={{ height: 500, width: 802 }} // the grid will fill the size of the parent container
    >
      <Row >
        <Col>
          <Button variant='primary' onClick={handleNew}>Nueva Litigio</Button>
        </Col>
        <Col>
          <Button variant='warning' onClick={handleEdit}>Modificar Litigio</Button>
        </Col>
        <Col>
          <Button variant='danger' onClick={handleDelete}>Eliminar Litigio</Button>
        </Col>
      </Row>
      <div>
        <FormLabel>Litigio seleccionado: </FormLabel>
        <span id="selectedRows"></span>
      </div>
      <AgGridReact
        ref={gridRef}
        rowData={litigations.response}
        columnDefs={colDefs}
        rowSelection={"single"}
        onSelectionChanged={onSelectionChanged}
      />
    </div>
  )
}