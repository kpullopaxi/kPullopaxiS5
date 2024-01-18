using kPullopaxiS5.Models;

namespace kPullopaxiS5.Vistas;

public partial class vPrincipal : ContentPage
{
	public vPrincipal()
	{
		InitializeComponent();
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        App.personRepo.AddNewPerson(txtName.Text);
        statusMessage.Text = App.personRepo.StatusMessage;
    }

    private void btnMostrar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        List<Persona> people = App.personRepo.GetAllPeorle();
        ListaPersona.ItemsSource = people;

            

    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        int personId = Convert.ToInt32(txtId.Text);
        App.personRepo.DeletePerson(personId);

        statusMessage.Text = App.personRepo.StatusMessage;

    }

private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        App.personRepo.UpdatePerson(Convert.ToInt32(txtId.Text), txtName.Text);
        statusMessage.Text = App.personRepo.StatusMessage;
    }

}






